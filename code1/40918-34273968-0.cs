    using System.Diagnostics;
    
    .....    
    
    static void Main()
    {
       Process thisProcess = Process.GetCurrentProcess();
       foreach(Process p in Process.GetProcessesByName(thisProcess.ProcessName))
       {
          if(p.Id != thisProcess.Id)
          {
             // Do whatever u want here to alert user to multiple instance
             return;
          }
       }
       // Continue on with opening application
