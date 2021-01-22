        [DllImport("user32.dll")]
        public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        [DllImport("kernel32")]
        public static extern IntPtr GetConsoleWindow();
        [DllImport("Kernel32")]
        private static extern bool SetConsoleCtrlHandler(EventHandler handler, bool add);
        static void Main(string[] args)
        {
            IntPtr hConsole = GetConsoleWindow();
            if (IntPtr.Zero != hConsole)
            {
                ShowWindow(hConsole, 0); 
            }
        }
