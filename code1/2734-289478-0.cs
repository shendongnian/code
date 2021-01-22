    using System.Threading;
    using System.Diagnostics;
    
    //namespace...class...method
    
    Process thisProc = Process.GetCurrentProcess();
    PerformanceCounter PC = new PerformanceCounter();
    
    PC.CategoryName = "Process";
    PC.CounterName = "Working Set - Private";
    PC.InstanceName = thisProc.ProcessName;
    
    while (true)
    {
     String privMemory = (PC.NextValue()/1000).ToString()+"KB (Private Bytes)";
     //Do something with string privMemory
    
     Thread.Sleep(1000);
    }
