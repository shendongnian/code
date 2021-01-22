    using System.Runtime.InteropServices;
    
    [StructLayout(LayoutKind.Sequential)]
    public struct POINT
    {
        public int X;
        public int Y;
    
        public POINT(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    
        public static implicit operator System.Drawing.Point(POINT p)
        {
            return new System.Drawing.Point(p.X, p.Y);
        }
            public static implicit operator POINT(System.Drawing.Point p)
        {
            return new POINT(p.X, p.Y);
        }
    }
    
    [StructLayout(LayoutKind.Sequential)]
    public struct MSG
    {
        public IntPtr hwnd;
        public UInt32 message;
        public IntPtr wParam;
        public IntPtr lParam;
        public UInt32 time;
        public POINT pt;
    }
    
    [DllImport("coredll.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool GetMessage(out MSG lpMsg, IntPtr hWnd, uint wMsgFilterMin,
       uint wMsgFilterMax);
    
    [DllImport("coredll.dll")]
    public static extern bool TranslateMessage([In] ref MSG lpMsg);
    
    [DllImport("coredll.dll")]
    public static extern IntPtr DispatchMessage([In] ref MSG lpmsg);
