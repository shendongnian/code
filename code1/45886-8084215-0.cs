    long TIMEOUT = 60000; // 1 minute
    long INTERVAL = 1000; // 1 second
    System.DateTime startTime = System.DateTime.Now;    
    while (check_condition())
    {
        System.Threading.Thread.Sleep(INTERVAL);
        long elapsedTime = System.DateTime.Now.Millisecond - startTime.Millisecond;
    
        if (elapsedTime > TIMEOUT)
        {
            throw new Exception("Timeout exceeded");
        }
    }
