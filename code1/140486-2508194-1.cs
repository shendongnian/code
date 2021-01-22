    private void saveJpeg(string path, Bitmap img, long quality)
    {
        EncoderParameter parameter = new EncoderParameter(Encoder.Quality, quality);
        ImageCodecInfo encoder = this.getEncoderInfo("image/jpeg");
        if (encoder != null)
        {
            EncoderParameters encoderParams = new EncoderParameters(1);
            encoderParams.Param[0] = parameter;
            img.Save(path, encoder, encoderParams);
        }
    }
    private ImageCodecInfo getEncoderInfo(string mimeType)
    {
        ImageCodecInfo[] imageEncoders = ImageCodecInfo.GetImageEncoders();
        for (int i = 0; i < imageEncoders.Length; i++)
        {
            if (imageEncoders[i].MimeType == mimeType)
            {
                return imageEncoders[i];
            }
        }
        return null;
    }
 
 
