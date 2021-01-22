    using System;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    
    class Program {
        static void Main(string[] args) {
            var prc = Process.GetProcessesByName("notepad");
            if (prc.Length > 0) {
                SetForegroundWindow(prc[0].MainWindowHandle);
            }
        }
        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);
    }
