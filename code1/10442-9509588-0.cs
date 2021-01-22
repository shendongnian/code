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
                {
                    InputSimulator.SimulateKeyUp(key);
                    ctr.Dispose();
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
