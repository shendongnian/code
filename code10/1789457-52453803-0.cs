    int screenLeft = SystemInformation.WorkingArea.Left;
    int screenTop = SystemInformation.VirtualScreen.Top;
    int screenCount = Screen.AllScreens.Length;
    int maxWidth = Screen.AllScreens.Max(m => m.Bounds.Width);
    int maxHeight = Screen.AllScreens.Max(m => m.Bounds.Height);
    int screenWidth = maxWidth * screenCount;
    int screenHeight = maxHeight;
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
