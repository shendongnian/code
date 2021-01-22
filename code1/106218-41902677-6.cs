    public static void localProcessKill(string processName)
    {
        foreach (Process p in Process.GetProcessesByName(processName))
        {
            p.Kill();
        }
    }
