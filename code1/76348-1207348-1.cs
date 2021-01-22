		static void Main() 
		{
            using (Mutex mutex = new Mutex(false, @"Global\" + appGuid)) {
                if (!mutex.WaitOne(0, false)) {
                    string processName = GetProcessName();
                    BringOldInstanceToFront(processName);
                }
                else {
                    GC.Collect();
                    Application.Run(new Voting());
                }
            }
		}
	    private static void BringOldInstanceToFront(string processName) {
	        Process[] RunningProcesses = Process.GetProcessesByName(processName);
	        if (RunningProcesses.Length > 0) {
	            Process runningProcess = RunningProcesses[0];
	            if (runningProcess != null) {
	                IntPtr mainWindowHandle = runningProcess.MainWindowHandle;
	                NativeMethods.ShowWindowAsync(mainWindowHandle, (int) WindowConstants.ShowWindowConstants.SW_SHOWMINIMIZED);
                NativeMethods.ShowWindowAsync(mainWindowHandle, (int) WindowConstants.ShowWindowConstants.SW_RESTORE);
	            }
	        }
	    }
