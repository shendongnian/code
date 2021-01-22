    autoRestartThread = new System.Threading.Thread(autoRestartThreadRun);
    autoRestartThread.Start();
 ...
    private void autoRestartThreadRun()
    {
    	try {
    		DateTime nextRestart = DateAndTime.Today.Add(CurrentSettings.AutoRestartTime);
    		if (nextRestart < DateAndTime.Now) {
    			nextRestart = nextRestart.AddDays(1);
    		}
    
    		while (true) {
    			if (nextRestart < DateAndTime.Now) {
    				LogInfo("Auto Restarting Service");
    				Process p = new Process();
    				p.StartInfo.FileName = "cmd.exe";
    				p.StartInfo.Arguments = string.Format("/C net stop {0} && net start {0}", "\"My Service Name\"");
    				p.StartInfo.LoadUserProfile = false;
    				p.StartInfo.UseShellExecute = false;
    				p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
    				p.StartInfo.CreateNoWindow = true;
    				p.Start();
    			} else {
    				dynamic sleepMs = Convert.ToInt32(Math.Max(1000, nextRestart.Subtract(DateAndTime.Now).TotalMilliseconds / 2));
    				System.Threading.Thread.Sleep(sleepMs);
    			}
    		}
    	} catch (ThreadAbortException taex) {
    	} catch (Exception ex) {
    		LogError(ex);
    	}
    }
