    ManualResetEvent mrse = new ManualResetEvent(false);
    public void run() 
    { 
        while(true) 
        { 
            mrse.WaitOne();
            printMessageOnGui("Hey"); 
            Thread.Sleep(2000); . . 
        } 
    }
    
    public void Resume()
    {
        mrse.Set();
    }
    
    public void Pause()
    {
        mrse.Reset();
    }
