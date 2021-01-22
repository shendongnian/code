    // Programmatically set process affinity
    var process = System.Diagnostics.Process.GetCurrentProcess();
    // Set Core 0
    process.ProcessorAffinity = new IntPtr(0x0001);
    
