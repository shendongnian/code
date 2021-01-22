    [MTAThread] // MDbg is MTA threaded
    static void Main(string[] args)
    {
        MDbgEngine debugger = new MDbgEngine();
        debugger.Options.StopOnModuleLoad = true;
        // Launch the debuggee.            
        int pid = Process.GetProcessesByName("VS2010Playground")[0].Id;
        MDbgProcess proc = debugger.Attach(pid);
        proc.Go();
        if (proc.IsAlive)
        {
            proc.AsyncStop().WaitOne();
            Console.WriteLine(debugger.Process.Active.AppDomains.Count);
            if ((debugger.Process.Active.AppDomains.Count > 0)
            {
                Console.WriteLine((debugger.Process.Active.AppDomains[0].CorAppDomain);
            }
        }
        Console.WriteLine("Done!");
    } 
