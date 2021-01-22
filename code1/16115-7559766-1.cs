    public class MoveToForeground
    {
        [DllImportAttribute("User32.dll")]
        private static extern int FindWindow(String ClassName, String WindowName);
    
        const int SWP_NOMOVE        = 0x0002;
        const int SWP_NOSIZE        = 0x0001;            
        const int SWP_SHOWWINDOW    = 0x0040;
        const int SWP_NOACTIVATE    = 0x0010;
        [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
        public static extern IntPtr SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int Y, int cx, int cy, int wFlags);
    
        public static void DoOnProcess(string processName)
        {
            var allProcs = Process.GetProcessesByName(processName);
            if (allProcs.Length > 0)
            {
                Process proc = allProcs[0];
                int hWnd = FindWindow(null, proc.MainWindowTitle.ToString());
                // Change behavior by settings the wFlags params. See http://msdn.microsoft.com/en-us/library/ms633545(VS.85).aspx
                SetWindowPos(new IntPtr(hWnd), 0, 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE | SWP_SHOWWINDOW | SWP_NOACTIVATE);
            }
        }
    }
