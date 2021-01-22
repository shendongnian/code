        private static bool ApplicationIsAlreadyRunning()
        {
            var currentProcess = Process.GetCurrentProcess();
            var processes = Process.GetProcessesByName(currentProcess.ProcessName);
            // test if there's another process running in current session.
            return processes.Any(prc => prc.SessionId == currentProcess.SessionId && processes.Length > 1);
        }
