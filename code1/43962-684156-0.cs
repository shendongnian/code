    private void CompressAndSaveImage(Image img, string fileName, 
            long quality) {
        EncoderParameters parameters = new EncoderParameters(1);
        parameters.Param[0] = new EncoderParameter(Encoder.Quality, quality);
        img.Save(fileName, GetCodecInfo("image/jpeg"), parameters);
    }
    private static ImageCodecInfo GetCodecInfo(string mimeType) {
        foreach (ImageCodecInfo encoder in ImageCodecInfo.GetImageEncoders())
            if (encoder.MimeType == mimeType)
                return encoder;
        throw new ArgumentOutOfRangeException(
            string.Format("'{0}' not supported", mimeType));
    }
