        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();/
        public static string GetForegroundWindowsName()
        {
            Process[] allproc = Process.GetProcesses();
            IntPtr ii = GetForegroundWindow();
            foreach (Process proc in allproc)
            {
                if (ii == proc.MainWindowHandle)
                {
                    return proc.ProcessName;
                }
            }
            return "";
        }
