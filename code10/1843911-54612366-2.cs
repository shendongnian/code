      public void SystemEventLoggerTimer(CancellationToken cancelToken)
            {
                SysEvntLogFileChckTimerRun = true;
        
                Task.Run(async () =>
                {
                    // Keep this task alive until it is cancelled
                    while (!cancelToken.IsCancellationRequested)
                    {
                        await Task.Delay(TimeSpan.FromMinutes(60));
                        CheckFileOverflow();
                    }
                });
            }
