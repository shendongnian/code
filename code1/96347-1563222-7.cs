    public async Task DoWithRetryAsync(Func<Task> action, TimeSpan sleepPeriod, int tryCount = 3)
    {
        if (tryCount <= 0)
            throw new ArgumentOutOfRangeException(nameof(tryCount));
    
        while (true) {
            try {
                await action();
                return; // success!
            } catch {
                if (--tryCount == 0)
                    throw;
                await Task.Delay(sleepPeriod);
            }
       }
    }
