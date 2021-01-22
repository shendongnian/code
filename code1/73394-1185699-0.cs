    // Create parameters
    EncoderParameters params = new EncoderParameters (1);
    
    // Set quality (100)
    params.Param[0] = new EncoderParameter(Encoder.Quality, 100);
    
    // Create encoder info
    ImageCodecInfo codec = null;
    foreach (ImageCodecInfo codectemp in ImageCodecInfo.GetImageDecoders())
    {
        if (codectemp.MimeType == "image/jpeg")
        {
            codec = codectemp;
            break;
        }
    }
    
    // Check
    if (codec == null)
        throw new Exception("Codec not found for image/jpeg");
    
    // Save
    image.Save(filename, codec, params);
