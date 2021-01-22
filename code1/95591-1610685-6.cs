        /// <summary>
        /// The GetForegroundWindow function returns a handle to the foreground window.
        /// </summary>
        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();
        static bool IsProcessFocused(string processname)
        {
            if (processname == null || processname.Length == 0)
            {
                throw new ArgumentNullException("processname");
            }
            Process[] runninProcesses = Process.GetProcessesByName(processname);
            IntPtr activeWindowHandle = GetForegroundWindow();
            foreach (Process process in runninProcesses)
            {
                if (process.MainWindowHandle.Equals(activeWindowHandle))
                {
                    return true;
                }
            }
            // Process was not found or didn't had the focus.
            return false;
        }
