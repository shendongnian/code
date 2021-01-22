    Monitor.Enter();
    while(!done)
    {
        while(!ready)
        {
            Monitor.Wait();
        }
    
        // do something, and...
        if(weChangedState)
        {
             Monitor.Pulse();
        }
    }
    Monitor.Exit();
