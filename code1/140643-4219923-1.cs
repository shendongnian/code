using System.Diagnostics;
...
  Process Proc = Process.GetCurrentProcess();
  long AffinityMask = (long)Proc.ProcessorAffinity;
  AffinityMask |= 0x000F; // use only any of the first 4 processors available
  Proc.ProcessorAffinity = (IntPtr)AffinityMask;
 
  ProcessThread Thread = Proc.Threads[0];
  AffinityMask |= 0x0002; // use only the second processor
  Thread.ProcessorAffinity = (IntPtr)AffinityMask;
...
