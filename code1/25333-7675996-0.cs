    Encoder encoder = Encoder.SaveFlag;
    ImageCodecInfo encoderInfo = ImageCodecInfo.GetImageEncoders().First(i => i.MimeType == "image/tiff";
    EncoderParameters encoderParameters = new EncoderParameters(1);
    encoderParameters.Param[0] = new EncoderParameter(encoder, (long)EncoderValue.MultiFrame);
    			
    // Save the first frame of the multi page tiff
    Bitmap firstImage = (Bitmap) _scannedPages[0].RawContent;
    firstImage.Save(fileName, encoderInfo, encoderParameters);
    
    encoderParameters.Param[0] = new EncoderParameter(encoder, (long)EncoderValue.FrameDimensionPage);
    
    // Add the remining images to the tiff
    for (int i = 1; i < _scannedPages.Count; i++)
    {
       Bitmap img = (Bitmap) _scannedPages[i].RawContent;
       firstImage.SaveAdd(img, encoderParameters);
    }
    
    // Close out the file
    encoderParameters.Param[0] = new EncoderParameter(encoder, (long)EncoderValue.Flush);
    firstImage.SaveAdd(encoderParameters);
