`public static class MonoScreenShooter
    {
        public static void TakeScreenshot(string filePath)
        {
			using (Bitmap bmpScreenCapture = new Bitmap(Screen.PrimaryScreen.Bounds.Width,
										Screen.PrimaryScreen.Bounds.Height))
			{
				using (Graphics g = Graphics.FromImage(bmpScreenCapture))
				{
					g.CopyFromScreen(Screen.PrimaryScreen.Bounds.X,
									 Screen.PrimaryScreen.Bounds.Y,
									 0, 0,
									 bmpScreenCapture.Size,
									 CopyPixelOperation.SourceCopy);
				}
				bmpScreenCapture.Save(filePath, System.Drawing.Imaging.ImageFormat.Jpeg);
			}
		}
        }
    }`
