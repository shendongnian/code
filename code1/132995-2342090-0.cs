    GC.Collect();
    GC.WaitForPendingFinalizers();
    GC.Collect();
    
    var before = System.Diagnostics.Process.GetCurrentProcess().VirtualMemorySize64;
    
    // performs operations here
    
    var after = System.Diagnostics.Process.GetCurrentProcess().VirtualMemorySize64;
