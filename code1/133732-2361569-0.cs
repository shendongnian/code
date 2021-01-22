    public Bitmap CaptureScreen()
    {
        Bitmap b = new Bitmap(SystemInformation.VirtualScreen.Width, SystemInformation.VirtualScreen.Height);
        Graphics g = Graphics.FromImage(b);
        g.CopyFromScreen(0, 0, 0, 0, b.Size);
        g.Dispose();
        return b;
    }
