                foreach (var process in Process.GetProcessesByName("WinSCP"))
                {
                    process.Kill();
                }
                (Process.GetCurrentProcess()).Kill();
