    Process p = Process.GetCurrentProcess(); // getting current running process of the app
    foreach (ProcessThread pt in p.Threads)
    {
        // use pt.Id / pt.TotalProcessorTime / pt.UserProcessorTime / pt.PrivilegedProcessorTime
    }
