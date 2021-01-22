    private static void SaveJpeg(this Image img, string filename, int quality)
    {
      EncoderParameter qualityParam = new EncoderParameter(Encoder.Quality, (long)quality);
      ImageCodecInfo jpegCodec = GetEncoderInfo("image/jpeg");
      EncoderParameters encoderParams = new EncoderParameters(1);
      encoderParams.Param[0] = qualityParam;
      img.Save(filename, jpegCodec, encoderParams);
    }
