        private static bool ApplicationIsAlreadyRunning()
        {
            var currentProcess = Process.GetCurrentProcess();
            var processes = Process.GetProcessesByName(currentProcess.ProcessName);
            // test if there's another process running in current session.
            var intTotalRunningInCurrentSession = processes.Count(prc => prc.SessionId == currentProcess.SessionId);
            return intTotalRunningInCurrentSession > 1;
        }
