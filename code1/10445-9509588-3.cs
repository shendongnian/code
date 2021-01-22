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
                else if (startCount != -1)
                { 
                    startCount = -1; 
                    timer.Dispose();
                    ctr.Dispose();                    
                    InputSimulator.SimulateKeyUp(key);
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
