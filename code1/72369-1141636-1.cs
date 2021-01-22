    private readonly object padlock = new object();
    private volatile bool stopping = false;
    public void Stop() // Could make this Dispose if you want
    {
        stopping = true;
        lock (padlock)
        {
            Monitor.Pulse(padlock);
        }
    }
    private void ThreadedWork()
    {
        while (!stopping)
        {
            DoWork();
            lock (padlock)
            {
                Monitor.Wait(padlock, TimeSpan.FromMinutes(15));
            }
        }
    }
