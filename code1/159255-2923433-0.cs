    class Program
    {
        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool FlashWindowEx(ref FLASHWINFO pwfi);
        [StructLayout(LayoutKind.Sequential)]
        public struct FLASHWINFO
        {
            public UInt32 cbSize;
            public IntPtr hwnd;
            public UInt32 dwFlags;
            public UInt32 uCount;
            public UInt32 dwTimeout;
        }
        public const UInt32 FLASHW_STOP = 0;
        public const UInt32 FLASHW_CAPTION = 1;
        public const UInt32 FLASHW_TRAY = 2;
        public const UInt32 FLASHW_ALL = 3;
        public const UInt32 FLASHW_TIMER = 4;
        public const UInt32 FLASHW_TIMERNOFG = 12; 
        static void Main(string[] args)
        {
            // Get the window handle on startup
            IntPtr hWnd = GetConsoleWindowHandle();
            // Give you a few seconds to alt-tab away :)
            Thread.Sleep(2000);
            // Flash on the task bar, until the window becomes the foreground window.
            // Constants for other behaviors are defined above.
            FLASHWINFO fInfo = new FLASHWINFO();
            fInfo.cbSize = Convert.ToUInt32(Marshal.SizeOf(fInfo));
            fInfo.hwnd = hWnd;
            fInfo.dwFlags = FLASHW_TRAY | FLASHW_TIMERNOFG;
            fInfo.uCount = UInt32.MaxValue;
            fInfo.dwTimeout = 0;
            FlashWindowEx(ref fInfo);
            // Wait for input so the app doesn't finish right away.
            Console.ReadLine();
        }
        static IntPtr GetConsoleWindowHandle()
        {
            string originalTitle = Console.Title;
            string uniqueTitle = Guid.NewGuid().ToString();
            Console.Title = uniqueTitle;
            
            // You may need to insert a delay here as described in the article.
            // For me, it worked fine without any delays.
            IntPtr hWnd = FindWindow(null, uniqueTitle);
            Console.Title = originalTitle;
            return hWnd;
        }
    }
