    Process[] processRunning = Process.GetProcesses();
	foreach (Process pr in processRunning)
	{
		if (pr.ProcessName == "Adobe Desktop Service")
		{
			var hWnd = pr.MainWindowHandle.ToInt32();
			// hWnd.Dump(); // xxx.Dump() is for linqpad output
		}
	}
