    public async Task LaunchMonitorThread(CancellationToken token)
    {
        while (!token.IsCancellationRequested)
        {
            try
            {
                //Check system status
                //Use task.delay instead of thread.sleep:
                await Task.Delay(5000);
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred. Resuming on next loop...");
            }
        }
    }
