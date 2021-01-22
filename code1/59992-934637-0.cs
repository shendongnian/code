    Process p = Process.GetCurrentProcess;
    foreach (ProcessThread pt in p.Threads)
    {
        // use pt.Id / pt.TotalProcessorTime / pt.UserProcessorTime / pt.PrivilegedProcessorTime
    }
