    using System;
    using System.Runtime.InteropServices;
    using System.Diagnostics;
    
    [StructLayout(LayoutKind.Sequential)]
    struct RECT
    {
        public int left;
        public int top;
        public int right;
        public int bottom;
    }
    
    class WindowHelper
    {
        [DllImport("user32.dll")]
        static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth,
        int nHeight, bool bRepaint);
    
        static void SetWindowRect()
        {
            Process p = new Process();
            p.StartInfo.FileName = "PPT.exe";
            p.Start();
            p.WaitForInputIdle();
            IntPtr hWnd = p.MainWindowHandle;
            int width = 300;
            int height = 600;
            // you can use Screen.PrimaryScreen.WorkingArea to set proper size
            MoveWindow(hWnd, 0, 0, width, height, true);
        }
    }
