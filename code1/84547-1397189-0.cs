		Random r = new Random();
		for (int i = 0; i < max; i++)
		{
			System.Diagnostics.Debugger.Break()
			int size = 1 + i;
			int width = 1 + i;
			SaveBitmap(@"C:\Projects\test.jpg", ImageFormat.Jpeg, "hello", size, width, Color.Black, Color.White, "Arial", size, true);
			SaveBitmap(@"C:\Projects\test.png", ImageFormat.Jpeg, "hello", size, width, Color.Black, Color.White, "Arial", size, true);
			SaveBitmap(@"C:\Projects\test.jpg", ImageFormat.Jpeg, "hello", size, width, Color.Black, Color.White, "Arial", size, false);
			SaveBitmap(@"C:\Projects\test.png", ImageFormat.Jpeg, "hello", size, width, Color.Black, Color.White, "Arial", size, false);
		}
		public static void SaveBitmap(string filename, ImageFormat format, string text, int height, int width, Color foregroundColor, Color backgroundColor, string fontName, int fontSize, bool antialias)
		{
			using (Image source = CreateBitmap(text, height, width, foregroundColor, backgroundColor, fontName, fontSize, antialias))
				source.Save(filename, format);
			using (Image imgLoaded = Bitmap.FromFile(filename))
			{
				if (imgLoaded.RawFormat.Guid != format.Guid)
					throw new InvalidOperationException();
			}
		}
