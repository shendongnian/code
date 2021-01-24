    internal volatile int needsPoll = 0;
    
    internal SemaphoreSlim pollers = new SemaphoreSlim(1, 1);
    
    // Called on start and on each message    
    public Task EnsurePoller()
    {
        needsPoll = 1;
        return Poll();
    }
    
    internal Task Poll()
    {
        // fast-path for when an existing poller already began polling
        //
        // when you're processing many messages, e.g. an unprocessed queue
        // with thousands of messages, it may happen very often
        if (needsPoll != 1)
        {
            return Task.CompletedTask;
        }
        return PollInternal();
    }
    
    internal async Task PollInternal()
    {
        do
        {
            if (pollers.Wait(TimeSpan.Zero))
            {
                try
                {
                    while (Interlocked.CompareExchange(ref needsPoll, 0, 1) == 1)
                    {
                        // actually poll, maybe trigger processing
                    }
                }
                finally
                {
                    pollers.Release();
                }
            }
            // double-check
        } while (needsPool == 1);
    }
