    [StructLayout(LayoutKind.Sequential)]
    public struct RECT
    {
        public int X;
        public int Y;
        public int Width;
        public int Height;
    }
    
    [DllImport("user32.dll", SetLastError = true)]
    public static extern IntPtr FindWindow(string lpClassName, string lpWindowName); 
    
    [DllImport("user32.dll", SetLastError = true)]
    public static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);
