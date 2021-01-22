    private static TimeSpan InfiniteTimeout = TimeSpan.FromMilliseconds(-1); 
    private const Int32 MAX_WAIT = 100; 
    public static bool Wait(WaitHandle handle, TimeSpan timeout) 
    { 
        Int32 expireTicks; 
        bool signaled; 
        Int32 waitTime; 
        bool exitLoop; 
        
        // guard the inputs 
        if (handle == null) { 
            throw new ArgumentNullException("handle"); 
        } 
        else if ((handle.SafeWaitHandle.IsClosed)) { 
            throw new ArgumentException("closed wait handle", "handle"); 
        } 
        else if ((handle.SafeWaitHandle.IsInvalid)) { 
            throw new ArgumentException("invalid wait handle", "handle"); 
        } 
        else if ((timeout < InfiniteTimeout)) { 
            throw new ArgumentException("invalid timeout <-1", "timeout"); 
        } 
        
        // wait for the signal 
        expireTicks = (int)Environment.TickCount + timeout.TotalMilliseconds; 
        do { 
            if (timeout.Equals(InfiniteTimeout)) { 
                waitTime = MAX_WAIT; 
            } 
            else { 
                waitTime = (expireTicks - Environment.TickCount); 
                if (waitTime <= 0) { 
                    exitLoop = true; 
                    waitTime = 0; 
                } 
                else if (waitTime > MAX_WAIT) { 
                    waitTime = MAX_WAIT; 
                } 
            } 
            
            if ((handle.SafeWaitHandle.IsClosed)) { 
                exitLoop = true; 
            } 
            else if (handle.WaitOne(waitTime, false)) { 
                exitLoop = true; 
                signaled = true; 
            } 
            else { 
                if (Application.MessageLoop) { 
                    Application.DoEvents(); 
                } 
                else { 
                    Thread.Sleep(1); 
                } 
            } 
        } 
        while (!exitLoop); 
        
        return signaled;
    }
