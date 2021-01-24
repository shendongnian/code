    [DllImport("gdi32.dll", SetLastError = true, CharSet = CharSet.Auto)]
    internal static extern IntPtr CreateDC(string lpszDriver, string lpszDevice, string lpszOutput, IntPtr lpInitData);
    [DllImport("Gdi32.dll", SetLastError = true, EntryPoint = "DeleteDC")]
    internal static extern bool DeleteDC([In] IntPtr hdc);  
    public static IntPtr CreateDCFromDeviceName(string deviceName)
    {
        return CreateDC(deviceName, null, null, IntPtr.Zero);
    }
    Screen[] screens = Screen.AllScreens;
    IntPtr screenDC1 = CreateDCFromDeviceName(screens[0].DeviceName);
    IntPtr screenDC2 = CreateDCFromDeviceName(screens[1].DeviceName);
    using (Graphics g1 = Graphics.FromHdc(screenDC1))
    using (Graphics g2 = Graphics.FromHdc(screenDC2))
    using (Pen pen = new Pen(Color.Red, 10))
    {
        g1.DrawRectangle(pen, new Rectangle(new Point(100, 100), new Size(200, 200)));
        g2.DrawRectangle(pen, new Rectangle(new Point(100, 100), new Size(200, 200)));
    }
    DeleteDC(screenDC1);
    DeleteDC(screenDC2);
