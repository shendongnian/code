    thread1.IsBackground = true;
    thread2.IsBackground = true;
    public void start()
    {
     while(true)
     {
        // ... do stuff
        Thread.Sleep(1000*60*5) // sleep for 5 minutes
     }
    }
    public void TimerMeth()
    {
        while(true)
        {
            file write = new file();
            write.write(RegKeys);
            Thread.Sleep(30000);
        }
    }
