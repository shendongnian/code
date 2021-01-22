        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);
        [DllImport("user32.dll")]
        private static extern bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);
        [DllImport("user32.dll")]
        private static extern bool IsIconic(IntPtr hWnd);
        private const int SW_HIDE = 0;
        private const int SW_SHOWNORMAL = 1;
        private const int SW_SHOWMINIMIZED = 2;
        private const int SW_SHOWMAXIMIZED = 3;
        private const int SW_SHOWNOACTIVATE = 4;
        private const int SW_RESTORE = 9;
        private const int SW_SHOWDEFAULT = 10;
     private static bool IsAlreadyRunning()
        {
            // get all processes by Current Process name
            Process[] processes = 
                Process.GetProcessesByName(
                    Process.GetCurrentProcess().ProcessName);
            // if there is more than one process...
            if (processes.Length > 1) 
            {
                // if other process id is OUR process ID...
                // then the other process is at index 1
                // otherwise other process is at index 0
                int n = (processes[0].Id == Process.GetCurrentProcess().Id) ? 1 : 0;
                // get the window handle
                IntPtr hWnd = processes[n].MainWindowHandle;
                // if iconic, we need to restore the window
                if (IsIconic(hWnd)) ShowWindowAsync(hWnd, SW_RESTORE);
                // Bring it to the foreground
                SetForegroundWindow(hWnd);
                return true;
            }
            return false;
        }
