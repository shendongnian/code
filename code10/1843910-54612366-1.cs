      public void SystemEventLoggerTimer(CancellationToken cancelToken)
            {
                SysEvntLogFileChckTimerRun = true;
        
                Task.Run(async () =>
                {
                    while (cancelToken.IsCancellationRequested)
                    {
                        await Task.Delay(TimeSpan.FromMinutes(60));
                        CheckFileOverflow();
                    }
                });
            }
