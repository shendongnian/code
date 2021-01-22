        static bool EnsureSingleInstance()
        {
            Process currentProcess = Process.GetCurrentProcess();
            var wmiQueryString = "SELECT ProcessId, ExecutablePath, CommandLine FROM Win32_Process";
            using (var searcher = new ManagementObjectSearcher(wmiQueryString))
            using (var results = searcher.Get())
            {
                var query = from p in Process.GetProcesses()
                            join mo in results.Cast<ManagementObject>()
                            on p.Id equals (int)(uint)mo["ProcessId"]
                            select new
                            {
                                Process = p,
                                Path = (string)mo["ExecutablePath"],
                                CommandLine = (string)mo["CommandLine"],
                            };
                var runningProcess = (from process in query
                                      where
                                        process.Process.Id != currentProcess.Id &&
                                        process.Process.ProcessName.Equals(
                                          currentProcess.ProcessName,
                                          StringComparison.Ordinal) &&
                                          process.Path == currentProcess.MainModule.FileName &&
                                          process.Process.SessionId == currentProcess.SessionId
                                      select process).FirstOrDefault();
                return runningProcess == null;
            }
        }
