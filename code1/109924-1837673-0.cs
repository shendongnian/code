    using Microsoft.Expression.Encoder;
    
    //...
    //skiped
    //...
    
    MediaItem mediaItem = new MediaItem(videoToEncode.SourceFilePath);
    mediaItem.ApplyPreset(PresetFilePath);
    Job job = new Job();
    job.ApplyPreset(PresetFilePath); // path to preset file, where settings of bit-rate, codec etc
    job.MediaItems.Add(mediaItem);
    job.EncodeProgress += OnProgress;
    job.EncodeCompleted += EncodeCompleted;
    job.DefaultMediaOutputFileName = "{OriginalFilename}.encoded.{DefaultExtension}";
    job.CreateSubfolder = false;
    job.OutputDirectory = videoToEncode.EncodedFilePath;
    job.Encode();
