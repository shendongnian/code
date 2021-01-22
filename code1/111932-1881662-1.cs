    using (Bitmap screenshot = new Bitmap(this.panel1.DisplayRectangle.Width, this.panel1.DisplayRectangle.Height))
    using (Graphics g = Graphics.FromImage(screenshot))
    {
        try
        {
            SendMessage(this.panel1.Handle, WM_PRINT, g.GetHdc().ToInt32(), (int)(DrawingOptions.PRF_CHILDREN | DrawingOptions.PRF_CLIENT | DrawingOptions.PRF_NONCLIENT | DrawingOptions.PRF_OWNED));
        }
        finally
        {
            g.ReleaseHdc();
        }
        screenshot.Save("temp.bmp");
    }
