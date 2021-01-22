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
