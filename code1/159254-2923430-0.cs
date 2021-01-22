    public static class FlashWindow
    {
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool FlashWindowEx(ref FLASHWINFO pwfi);
        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();
        [StructLayout(LayoutKind.Sequential)]
        public struct FLASHWINFO
        {
            public UInt32 cbSize;
            public IntPtr hwnd;
            public UInt32 dwFlags;
            public UInt32 uCount;
            public UInt32 dwTimeout;
        }
        public const UInt32 FLASHW_ALL = 3;
        public static void Flash()
        {
            FLASHWINFO fInfo = new FLASHWINFO();
            fInfo.cbSize = Convert.ToUInt32(Marshal.SizeOf(fInfo));
            fInfo.hwnd = GetConsoleWindow();
            fInfo.dwFlags = FLASHW_ALL;
            fInfo.uCount = UInt32.MaxValue;
            fInfo.dwTimeout = 0;
            FlashWindowEx(ref fInfo);
        }
    }
