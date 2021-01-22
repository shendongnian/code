    [DllImport("user32.dll")]
    static extern IntPtr GetDC(IntPtr hwnd);
    [DllImport("user32.dll")]
    static extern Int32 ReleaseDC(IntPtr hwnd, IntPtr hdc);
    [DllImport("gdi32.dll")]
    static extern uint GetPixel(IntPtr hdc, int nXPos, int nYPos);
    public static void getColor()
    {
        IntPtr hdc = GetDC(IntPtr.Zero);
        uint pixel = GetPixel(hdc, Cursor.Position.X, Cursor.Position.Y);
        ReleaseDC(IntPtr.Zero, hdc);
        System.Drawing.Color color = System.Drawing.Color.FromArgb((int)pixel);
        Console.WriteLine("Color is {0}", color);
    }
