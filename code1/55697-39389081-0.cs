    public static class ProcessExtensions
    {
        public static void KillRemoteProcess(this Process p, string user, string password)
        {
            new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "TaskKill.exe",
                    Arguments = string.Format("/pid {0} /s {1} /u {2} /p {3}", p.Id, p.MachineName, user, password),
                    WindowStyle = ProcessWindowStyle.Hidden,
                    CreateNoWindow = true
                }
            }.Start();
        }
    }
