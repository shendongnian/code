    using System;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    
    class Program
    {
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SetWindowPos(
            IntPtr hWnd, 
            IntPtr hWndInsertAfter, 
            int x, 
            int y, 
            int cx, 
            int cy, 
            int uFlags);
    
        private const int HWND_TOPMOST = -1;
        private const int SWP_NOMOVE = 0x0002;
        private const int SWP_NOSIZE = 0x0001;
    
        static void Main(string[] args)
        {
            IntPtr hWnd = Process.GetCurrentProcess().MainWindowHandle;
    
            SetWindowPos(hWnd, 
                new IntPtr(HWND_TOPMOST), 
                0, 0, 0, 0, 
                SWP_NOMOVE | SWP_NOSIZE);
            Console.ReadKey();
        }
    }
