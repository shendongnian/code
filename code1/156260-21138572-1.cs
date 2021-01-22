    public static void FlushMemory()
    {
        Process prs = Process.GetCurrentProcess();
        prs.MinWorkingSet = (IntPtr)(300000);
    }
