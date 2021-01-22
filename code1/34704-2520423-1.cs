    foreach (var p in Process.GetProcesses())
    {
       var performanceCounter = new PerformanceCounter("Process", "Creating Process ID", p.ProcessName);
       var parent = GetProcessIdIfStillRunning((int)performanceCounter.RawValue);
       Console.WriteLine(" Process {0}(pid {1} was started by Process {2}(Pid {3})",
                  p.ProcessName, p.Id, parent.ProcessName, parent.ProcessId );
    }
    //Below is helper stuff to deal with exceptions from 
    //looking-up no-longer existing parent processes:
    struct MyProcInfo
    {
        public int ProcessId;
        public string ProcessName;
    }
    static MyProcInfo GetProcessIdIfStillRunning(int pid)
    {
        try
        {
            var p = Process.GetProcessById(pid);
            return new MyProcInfo() { ProcessId = p.Id, ProcessName = p.ProcessName };
        }
        catch (ArgumentException)
        {
            return new MyProcInfo() { ProcessId = -1, ProcessName = "No-longer existant process" };
        }
    }
