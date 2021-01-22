    using System;
    using System.Diagnostics;
    public class ListProcs
    {
    public static void Main()
    {
      int totMemory = 0;
      Console.WriteLine("Info for all processes:");
      Process[] allProcs = Process.GetProcesses();
      foreach(Process thisProc in allProcs)
      {
         string procName = thisProc.ProcessName;
         DateTime started = thisProc.StartTime;
         int procID = thisProc.Id;
         int memory = thisProc.VirtualMemorySize;
         int priMemory = thisProc.PrivateMemorySize;
         int physMemory = thisProc.WorkingSet;
         totMemory += physMemory;
         int priority = thisProc.BasePriority;
         TimeSpan cpuTime = thisProc.TotalProcessorTime;
         Console.WriteLine("Process: {0}, ID: {1}", procName, procID);
         Console.WriteLine("    started: {0}", started.ToString());
         Console.WriteLine("    CPU time: {0}", cpuTime.ToString());
         Console.WriteLine("    virtual memory: {0}", memory);
         Console.WriteLine("    private memory: {0}", priMemory);
         Console.WriteLine("    physical memory: {0}", physMemory);
      }
      Console.WriteLine("\nTotal physical memory used: {0}", totMemory);
      }
      }
