﻿using Hudl.FFmpeg.Command;
using Hudl.FFmpeg.Filters.BaseTypes;
using Hudl.FFmpeg.Filters.Templates;
using Hudl.FFmpeg.Resources;
using Hudl.FFmpeg.Resources.BaseTypes;
using Hudl.FFmpeg.Settings;
using Hudl.FFmpeg.Settings.BaseTypes;
using Hudl.FFmpeg.Sugar;

namespace Hudl.FFmpeg.Samples.FFmpeg.Concat
{
    class CameraFlashVideo
    {
        public static void Run()
        {
            //set up ffmpeg command configuration with locations of default output folders, ffmpeg, and ffprobe.
            ResourceManagement.CommandConfiguration = CommandConfiguration.Create(
                @"c:\source\ffmpeg\bin\temp",
                @"c:\source\ffmpeg\bin\ffmpeg.exe",
                @"c:\source\ffmpeg\bin\ffprobe.exe");

            //create a factory 
            var factory = CommandFactory.Create();

            factory.CreateOutputCommand()
                .WithInput<VideoStream>(Assets.Utilities.GetVideoFile())
                .WithInput<VideoStream>(Assets.Utilities.GetVideoFile())
                .Filter(new CameraFlash("white"))
                .MapTo<Mp4>(@"c:\source\ffmpeg\bin\temp\foo.mp4", SettingsCollection.ForOutput(new OverwriteOutput()));
            factory.Render();
            
            //render the output
            factory.Render();
        }
    }
}