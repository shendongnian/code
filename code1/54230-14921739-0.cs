    System.Diagnostics.Process proc = assign your process here :-)
    int memsize = 0; // memsize in Megabyte
    PerformanceCounter PC = new PerformanceCounter();
    PC.CategoryName = "Process";
    PC.CounterName = "Working Set - Private";
    PC.InstanceName = proc.ProcessName;
    memsize = Convert.ToInt32(PC.NextValue()) / (int)(1024);
    PC.Close();
    PC.Dispose();
