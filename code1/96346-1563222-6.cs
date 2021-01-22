    public void DoWithRetry(Action action, TimeSpan sleepPeriod, int tryCount = 3)
    {
        if (tryCount <= 0)
            throw new ArgumentOutOfRangeException(nameof(tryCount));
        while (true) {
            try {
                action();
                break; // success!
            } catch {
                if (--tryCount == 0)
                    throw;
                Thread.Sleep(sleepPeriod);
            }
       }
    }
