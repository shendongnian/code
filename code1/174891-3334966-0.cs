    int waitTimeSecs = 120;    
    bool cleanExit = process.WaitForExit(waitTimeSecs * 1000);
    if (!process.HasExited)
    {
        process.CloseMainWindow();
        System.Threading.Thread.Sleep(2000);
    }
    
    if (!process.HasExited)
    {
        process.Kill();
        process.WaitForExit();
        // if an exception window has popped up, that needs to be killed too
        // DW20 is the Dr. Watson application error handling process
        foreach (var process in Process.GetProcessesByName("DW20"))
        {
            process.CloseMainWindow();
            System.Threading.Thread.Sleep(2000);
            if (!process.HasExited)
                process.Kill();
        }
    }
