        DateTime lastSleep = DateTime.Now;            
        while (true)
        {
            TimeSpan span = DateTime.Now - lastSleep;
            if (span.TotalMilliseconds > 700)
            {
                Thread.Sleep(300);
                lastSleep = DateTime.Now;
            }
        }
     
