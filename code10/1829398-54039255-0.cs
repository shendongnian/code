    public Icon ToIcon(Bitmap bmp)
    {
        IntPtr hicon = bmp.GetHicon();
        Icon icon = Icon.FromHandle(hicon);
        DestroyIcon(hicon); // prevent memory leak.
        return icon;
    }
    
    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    extern static bool DestroyIcon(IntPtr handle);
