    using Microsoft.Diagnostics.Runtime;
    using (DataTarget target = DataTarget.AttachToProcess(
        Process.GetCurrentProcess().Id, 5000, AttachFlag.Passive))
    {
        ClrRuntime runtime = target.ClrVersions.First().CreateRuntime();
        foreach (ClrThread thread in runtime.Threads)
        {
            IList<ClrStackFrame> stackFrames = thread.StackTrace;
            PrintStackTrace(stackFrames);            
        }
    }
