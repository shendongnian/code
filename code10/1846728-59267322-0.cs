     using (var engine = new Engine(Constants.targetFfmpegPath))
     {
        engine.ConvertProgressEvent += onProgress;
        engine.ConversionCompleteEvent += onComplete;
        engine.CustomCommand(string.Format(command, input, resolution, crf, output));
     }
