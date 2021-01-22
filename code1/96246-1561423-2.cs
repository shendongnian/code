    Monitor.Enter(lock);
    
    try
    {
        while(!done)
        {
            while(!ready)
            {
                Monitor.Wait(lock);
            }
        
            // do something, and...
    
            if(weChangedState)
            {
                 Monitor.Pulse(lock);
            }
        }
    }
    finally
    {
        Monitor.Exit(lock);
    }
