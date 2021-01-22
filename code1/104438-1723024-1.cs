    public void TimerMeth()
    {
        System.Timers.Timer timer = new System.Timers.Timer();
        timer.Elapsed += new ElapsedEventHandler(OnElapsedTime);
        timer.Interval = 300000;
        timer.Enabled = true;
        try
        {
            while(true)
            {
                OnElapsedTime(null, null); // you should change the signature
                Thread.Sleep(30000);
            }
        }
        catch(ThreadAbortException)
        {
            OnElapsedTime(null, null);
            throw;
        }
    }
