    public class MoveToForeground
    {
        [DllImportAttribute("User32.dll")]
        private static extern int FindWindow(String ClassName, String WindowName);
        [DllImportAttribute("User32.dll")]
        private static extern int SetForegroundWindow(int hWnd);
    
        public static void Do(string processName)
        {
            var allProcs = Process.GetProcessesByName(processName);
            if (allProcs.Length > 0)
            {
                Process proc = allProcs[0];
                int hWnd = FindWindow(null, proc.MainWindowTitle.ToString());
                SetForegroundWindow(hWnd);
            }
        }
    }
