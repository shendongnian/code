		private void ConvertTo24bppPNG(Stream imageDataAsStream, out byte[] data)
		{
			using ( Image img = Image.FromStream(imageDataAsStream) )
			{
				using ( Bitmap bmp = new Bitmap(img.Width, img.Height, PixelFormat.Format24bppRgb) )
				{
					// ensure resulting image has same resolution as source image
					// otherwise resulting image will appear scaled
					bmp.SetResolution(img.HorizontalResolution, img.VerticalResolution);
					using ( Graphics gfx = Graphics.FromImage(bmp) )
					{
						gfx.DrawImage(img, 0, 0);
					}
					using ( MemoryStream ms = new MemoryStream() )
					{
						bmp.Save(ms, ImageFormat.Png);
						data = new byte[ms.Length];
						ms.Position = 0;
						ms.Read(data, 0, (int) ms.Length);
					}
				}
			}
		}
