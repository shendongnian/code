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
