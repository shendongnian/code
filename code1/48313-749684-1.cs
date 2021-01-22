    foreach (Process p in Process.GetProcessesByName("winword"))
    {
        if (!p.HasExited)
        {
            p.Kill();
        }
    }
