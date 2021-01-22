    [DllImport("user32.dll")]
    public static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);           
    public static Size GetControlSize(IntPtr hWnd)
    {
        RECT pRect;
        Size cSize = new Size();
        // get coordinates relative to window
        GetWindowRect(hWnd, out pRect);
        cSize.Width = pRect.Right - pRect.Left;
        cSize.Height = pRect.Bottom - pRect.Top;
        return cSize;
    }
