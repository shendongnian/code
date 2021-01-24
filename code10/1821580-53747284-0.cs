    using System;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    class Program {
        static void Main(string[] args) {
            var proc = Process.GetProcessesByName("notepad");
            if (proc.Length > 0) {
                SetForegroundWindow(proc[0].MainWindowHandle);
            }
        }
        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);
