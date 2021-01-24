		result = TrackMsAccessPopups(log, result);
        private string TrackMsAccessPopups(ILogger log, string result)
        {
            while (IsFunctionRunning)
            {
                Thread.Sleep(1000);
                if (MsAccessProc != null)
                {
                    if (WhiteApplication == null)
                    {
                        WhiteApplication = TestStack.White.Application.Attach(MsAccessProc);
                    }
                    log.Log(LogLevel.Info, "GetWindows.");
                    WhiteWindows = WhiteApplication.GetWindows();
                    log.Log(LogLevel.Info, "GetWindows done.");
                    if (WhiteWindows.Count > (MsAccessApp.Visible ? 1 : 0))
                    {
                        IsFunctionRunning= false;
                        log.Log(LogLevel.Error, "MS Access has created a popup.");
                        result = $"MS Access has created a popup. Log in on {Environment.MachineName} to view the message.";
                    }
                }
            }
            WhiteApplication = null;
            return result;
        }
		
