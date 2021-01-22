    static Task SimulateKeyHold(VirtualKeyCode key, int holdDurationMs, 
                                int repeatDelayMs, int repeatRateMs, CancellationToken token)
    {
        var tcs = new TaskCompletionSource<object>();
        var ctr = new CancellationTokenRegistration();
        var startCount = Environment.TickCount;
            
        Timer timer = null;
        timer = new Timer(s =>         
        {
            lock (timer)
            {
                if (Environment.TickCount - startCount <= holdDurationMs)
                    InputSimulator.SimulateKeyDown(key);
                else
                { // there's a race condition here that may cause multiple KeyUp events
                    InputSimulator.SimulateKeyUp(key); //easy enough to fix 
                    ctr.Dispose();                    //if you care about it
                    timer.Dispose();
                    tcs.TrySetResult(null);
                }
            }
        });
        timer.Change(repeatDelayMs, repeatRateMs);
    
        if (token.CanBeCanceled)
            ctr = token.Register(() =>
                           {
                               timer.Dispose();
                               tcs.TrySetCanceled();
                           });
        return tcs.Task;
    }
