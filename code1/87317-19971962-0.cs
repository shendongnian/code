	public static class ImageCodecInfoX
	{
		private static Dictionary<Guid, ImageCodecInfoFull> _imageCodecsDictionary;
		public static Dictionary<Guid, ImageCodecInfoFull> ImageCodecsDictionary 
		{
			get
			{
				if (_imageCodecsDictionary == null) {
					_imageCodecsDictionary =
						ImageCodecInfo.GetImageDecoders()
						.Select(i => {
							var format = ImageFormats.Unknown;
							switch (i.FormatDescription.ToLower()) {
								case "jpeg": format = ImageFormats.Jpeg; break;
								case "png": format = ImageFormats.Png; break;
								case "icon": format = ImageFormats.Icon; break;
								case "gif": format = ImageFormats.Gif; break;
								case "bmp": format = ImageFormats.Bmp; break;
								case "tiff": format = ImageFormats.Tiff; break;
								case "emf": format = ImageFormats.Emf; break;
								case "wmf": format = ImageFormats.Wmf; break;
							}
							return new ImageCodecInfoFull(i) { Format = format };
						})
						.ToDictionary(c => c.CodecInfo.FormatID);
				}
				return _imageCodecsDictionary;
			}
		}
		public static ImageCodecInfoFull CodecInfo(this Image image)
		{
			ImageCodecInfoFull codecInfo = null;
			if (!ImageCodecsDictionary.TryGetValue(image.RawFormat.Guid, out codecInfo))
				return null;
			return codecInfo;
		}
		public static ImageFormats Format(this Image image)
		{
			var codec = image.CodecInfo();
			return codec == null ? ImageFormats.Unknown : codec.Format;
		}
	}
	public enum ImageFormats { Jpeg, Png, Icon, Gif, Bmp, Emf, Wmf, Tiff, Unknown }
	/// <summary>
	/// Couples ImageCodecInfo with an ImageFormats type.
	/// </summary>
	public class ImageCodecInfoFull
	{
		public ImageCodecInfoFull(ImageCodecInfo codecInfo = null)
		{
			Format = ImageFormats.Unknown;
			CodecInfo = codecInfo;
		}
		public ImageCodecInfo CodecInfo { get; set; }
		public ImageFormats Format { get; set; }
	}
