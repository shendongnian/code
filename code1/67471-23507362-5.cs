    private static void SaveJpeg(this Image img, string filename, int quality)
    {
      EncoderParameter qualityParam = new EncoderParameter(Encoder.Quality, (long)quality);
      ImageCodecInfo jpegCodec = GetEncoderInfo("image/jpeg");
      EncoderParameters encoderParams = new EncoderParameters(1);
      encoderParams.Param[0] = qualityParam;
      img.Save(filename, jpegCodec, encoderParams);
    }
	private static ImageCodecInfo GetEncoderInfo(string mimeType)
	{
	    var encoders = ImageCodecInfo.GetImageEncoders();
	    var encoder = encoders.SingleOrDefault(c => string.Equals(c.MimeType, mimeType, StringComparison.InvariantCultureIgnoreCase));
	    if (encoder == null) throw new Exception($"Encoder not found for mime type {mimeType}");
	    return encoder;
	}
