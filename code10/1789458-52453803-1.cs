            int screenCount = Screen.AllScreens.Length;
            int screenTop = SystemInformation.VirtualScreen.Top;
            int screenLeft = SystemInformation.VirtualScreen.Left;
            int screenWidth = Screen.AllScreens.Max(m => m.Bounds.Width);
            int screenHeight = Screen.AllScreens.Max(m => m.Bounds.Height);
            bool isVertical = (SystemInformation.VirtualScreen.Height < SystemInformation.VirtualScreen.Width);
            if (isVertical)
                screenWidth *= screenCount;
            else
                screenHeight *= screenCount;
            // Create a bitmap of the appropriate size to receive the screenshot.
            using (Bitmap bmp = new Bitmap(screenWidth, screenHeight, PixelFormat.Format32bppPArgb))
            {
                // Draw the screenshot into our bitmap.
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.CopyFromScreen(screenLeft, screenTop, 0, 0, bmp.Size);
                }
                // Make black color transparent
                bmp.MakeTransparent(Color.Black);
                bmp.Save("TestImage.png", ImageFormat.Png);
            }
