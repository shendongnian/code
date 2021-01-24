	public static void CutImage(Image image)
	{
		using (Bitmap source = new Bitmap(image))
		{
			using (Bitmap cuttedImage = source.Clone(new System.Drawing.Rectangle(250, 0, 5550, 4000), source.PixelFormat))
			{
				using (Bitmap copyImage = new Bitmap(cuttedImage.Width, cuttedImage.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb))
				{
					using (Graphics g = Graphics.FromImage(copyImage))
					{
						g.DrawImageUnscaled(cuttedImage, 0, 0);
						copyImage.Save(@"path\tmp.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
					}
				}
			}
		}
	}
