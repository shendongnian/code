        public static class Extensions
        {
            public static void ForceKill(this Process process)
            {
                using (Process killer = new Process())
                {
                    killer.StartInfo.FileName = "taskkill";
                    killer.StartInfo.Arguments = string.Format("/f /PID {0}", process.Id);
                    killer.StartInfo.CreateNoWindow = true;
                    killer.StartInfo.UseShellExecute = false;
                    killer.Start();
                    killer.WaitForExit();
                    if (killer.ExitCode != 0)
                    {
                        throw new Win32Exception(killer.ExitCode);
                    }
                }
            }
        }
