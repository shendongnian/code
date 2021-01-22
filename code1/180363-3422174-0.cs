    using System.Diagnostics;
    
    
    // Poll every 5 seconds
    while(true)
    {
        // Get a list of running processes
        Process[] processlist = Process.GetProcesses();
    
        // Do logging
        // ...
    
        Thread.Sleep(5000);
    }
