    const int attempts = 3;
    const int perAttemptSleep = 5000;
    const int perTrialSleep = 600000;
    
    while (true)
    {
        for (var i = 0; i < attempts; i++)
        {
            try
            {
                Connect();
                return;
            }
            catch (ConnectException)
            {
                Thread.Sleep(perAttemptSleep);
            }
        }
    
        Log();
        Thread.Sleep(perTrialSleep);
    }
