    public void Test()
    {
        RunSafely(() => Task.Delay(2000));
    }
    public Task RunSafely(Func<Task> job)
        => Task.Run(async () =>
        {
            try
            {
                await job();
            }
            catch (Exception)
            {
                //todo 
            }
        });
