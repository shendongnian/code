	public static void SaveJpeg(string path, Bitmap image)
	{
		SaveJpeg(path, image, 95L);
	}
	public static void SaveJpeg(string path, Bitmap image, long quality)
	{
		using (EncoderParameters encoderParameters = new EncoderParameters(1))
		using (EncoderParameter encoderParameter = new EncoderParameter(Encoder.Quality, quality))
		{
			ImageCodecInfo codecInfo = ImageCodecInfo.GetImageDecoders().First(codec => codec.FormatID == ImageFormat.Jpeg.Guid);
			encoderParameters.Param[0] = encoderParameter;
			image.Save(path, codecInfo, encoderParameters);
		}
	}
