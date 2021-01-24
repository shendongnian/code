    MediaEncodingProfile profile = MediaEncodingProfile.CreateWav(AudioEncodingQuality.Low);
    MediaTranscoder transcoder = new MediaTranscoder();
    PrepareTranscodeResult prepareOp = await
        transcoder.PrepareFileTranscodeAsync(source, destination, profile);
    if (prepareOp.CanTranscode)
    {
        var transcodeOp = prepareOp.TranscodeAsync();
    
        transcodeOp.Progress +=
            new AsyncActionProgressHandler<double>(TranscodeProgress);
        transcodeOp.Completed +=
            new AsyncActionWithProgressCompletedHandler<double>(TranscodeComplete);
    }
    else
    {
        switch (prepareOp.FailureReason)
        {
            case TranscodeFailureReason.CodecNotFound:
                System.Diagnostics.Debug.WriteLine("Codec not found.");
                break;
            case TranscodeFailureReason.InvalidProfile:
                System.Diagnostics.Debug.WriteLine("Invalid profile.");
                break;
            default:
                System.Diagnostics.Debug.WriteLine("Unknown failure.");
                break;
        }
    }
