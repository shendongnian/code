    public static class ImageExtensions
    {
    	public static void SaveJpeg(this Image img, string filePath, long quality)
    	{
    		var encoderParameters = new EncoderParameters(1);
    		encoderParameters.Param[0] = new EncoderParameter(Encoder.Quality, quality);
    		img.Save(filePath, GetEncoder(ImageFormat.Jpeg), encoderParameters);
    	}
    
    	public static void SaveJpeg(this Image img, Stream stream, long quality)
    	{
    		var encoderParameters = new EncoderParameters(1);
    		encoderParameters.Param[0] = new EncoderParameter(Encoder.Quality, quality);
    		img.Save(stream, GetEncoder(ImageFormat.Jpeg), encoderParameters);
    	}
    
    	static ImageCodecInfo GetEncoder(ImageFormat format)
    	{
    		ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();
    		return codecs.Single(codec => codec.FormatID == format.Guid);
    	}
    }
