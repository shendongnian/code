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
