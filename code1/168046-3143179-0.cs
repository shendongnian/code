    bool WaitUntilTheStackHasMember()
    {
        TimeSpan waitPeriod = TimeSpan.FromSeconds(10);
        int sleepPeriod = 100; // milliseconds
        DateTime startTime = DateTime.Now;
        while ((Resources.Count == 0) && ((DateTime.Now - startTime) < waitPeriod))
        {
            System.Threading.Thread.Sleep(sleepPeriod);
        }
        return Resources.Count > 0;
    }
