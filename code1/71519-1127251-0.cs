    public static void CheckSingleInstance()
    {
    	bool created = false;
    	_singleInstance = new Mutex(true, "PredefinedMutexName##1", out created);
    
    	if (!created)
    	{
    		MessageBox.Show("Another instance of this application is already running. Click OK to switch to that instance.", "Application running", MessageBoxButtons.OK, MessageBoxIcon.Information);
    
    		Process proc = Process.GetCurrentProcess();
    		Process[] procs = Process.GetProcessesByName(proc.ProcessName);
    		bool exit = false;
    		Process process = null;
    		foreach (Process p in procs)
    		{
    			if (p.Id != proc.Id && p.MainModule.FileName == proc.MainModule.FileName)
    			{
    				// ShowWindow(p.MainWindowHandle, 1/*SW_SHOWNORMAL*/);
    				process = p;
    				exit = true;
    			}
    		}
    		if (exit)
    		{
    			Application.Exit();
    
    			if (process != null)
    				NativeMethods.SetForegroundWindow(process.MainWindowHandle);
    
    			return;
    		}
    	}
    }
