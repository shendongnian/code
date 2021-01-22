    class Program
    {
        const int Hide = 0;
        const int Show = 1;
        [DllImport("Kernel32.dll")]
        private static extern IntPtr GetConsoleWindow();
        [DllImport("User32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int cmdShow);
        static void Main(string[] args)
        {
            Console.WriteLine("Press any key to hide me.");
            Console.ReadKey();
            IntPtr hWndConsole = GetConsoleWindow();
            if (hWndConsole != IntPtr.Zero)
            {
                ShowWindow(hWndConsole, Hide);
                System.Threading.Thread.Sleep(5000);
                ShowWindow(hWndConsole, Show);
            }
            Console.ReadKey();
        }
    }
