    private static void AttachProcess()
    {
    	var localByName = System.Diagnostics.Process.GetProcessesByName(_appName);
    
    	MessageFilter.Register();
    	var process = GetProcess(localByName[0].Id);
    	if (process != null)
    	{
    		process.Attach();
    		Console.WriteLine("Attached to {0}", process.Name);
    	}
    	MessageFilter.Revoke();
    }
    
    private static void StartProcess()
    {
    	System.Diagnostics.Process.Start("start.bat");
    
    	Console.WriteLine("Waiting to load the process...");
    	System.Threading.Thread.Sleep(3000);
    }
    
    private static Process GetProcess(int processId)
    {
    	// Visual Studio 2017 (15.0)
    	var dte = (DTE)Marshal.GetActiveObject("VisualStudio.DTE.15.0");
    	var processes = dte.Debugger.LocalProcesses.OfType<Process>();
    	return processes.SingleOrDefault(x => x.ProcessID == processId);
    }
