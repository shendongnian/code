		private static string GetThumbnailImageAsBase64String(string path)
		{
			if (path == null || !File.Exists(path))
			{
				var log = ContainerResolver.Container.GetInstance<ILog>();
				log.Info($"No file was found at path: {path}");
				return null;
			}
			var width = LibraryItemFileSettings.Instance.ThumbnailImageWidth;
			using (var image = Image.FromFile(path))
			{
				using (var thumbnail = image.GetThumbnailImage(width, width * image.Height / image.Width, null, IntPtr.Zero))
				{
					using (var memoryStream = new MemoryStream())
					{
						thumbnail.Save(memoryStream, ImageFormat.Png); // <= crash here 
						var bytes = new byte[memoryStream.Length];
						memoryStream.Position = 0;
						memoryStream.Read(bytes, 0, bytes.Length);
						return Convert.ToBase64String(bytes, 0, bytes.Length);
					}
				}
			}
		}
