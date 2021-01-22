    System.Diagnostics.Process[] ieProcs = Process.GetProcessesByName("IEXPLORE");
                            
    if (ieProcs.Length > 0)
    {
       foreach (System.Diagnostics.Process p in ieProcs)
       {                        
          String virtualMem = p.VirtualMemorySize64.ToString();
          String physicalMem = p.WorkingSet64.ToString();
          String cpu = p.TotalProcessorTime.ToString();                      
       }
    }
