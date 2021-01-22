     public DateTime GetProcessStartTime(string processName)
            {
                Process[] p = Process.GetProcessesByName(processName);
                if (p.Length <= 0) throw new Exception("Process not found!");
                return p[0].StartTime;
            }
