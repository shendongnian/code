    public static void FlushMemory()
    {
        Process prs = Process.GetCurrentProcess();
        try
        {
            prs.MinWorkingSet = (IntPtr)(300000);
        }
        catch (Exception exception)
        {
            throw new Exception();
        }
    }
