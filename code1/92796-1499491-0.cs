    static void Main(string[] args)
    {
        foreach (Process process in Process.GetProcessesByName("explorer"))
        {
            if (!process.HasExited)
            {
                process.Kill();
            }
        }
        Process.Start("explorer.exe");
    }
