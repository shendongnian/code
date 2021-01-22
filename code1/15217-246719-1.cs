    using System;
    using System.Threading;
    
    class TimerExample
    {
        static void Main()
        {
            AutoResetEvent autoEvent     = new AutoResetEvent(false);
            StatusChecker  statusChecker = new StatusChecker(10);
    
            // Create the delegate that invokes methods for the timer.
            TimerCallback timerDelegate = 
                new TimerCallback(statusChecker.CheckStatus);
    
            // Create a timer that signals the delegate to invoke 
            // CheckStatus after one second, and every 1/4 second 
            // thereafter.
            Console.WriteLine("{0} Creating timer.\n", 
                DateTime.Now.ToString("h:mm:ss.fff"));
            Timer stateTimer = 
                    new Timer(timerDelegate, autoEvent, 1000, 250);
    
            // When autoEvent signals, change the period to every 
            // 1/2 second.
            autoEvent.WaitOne(5000, false);
            stateTimer.Change(0, 500);
            Console.WriteLine("\nChanging period.\n");
    
            // When autoEvent signals the second time, dispose of 
            // the timer.
            autoEvent.WaitOne(5000, false);
            stateTimer.Dispose();
            Console.WriteLine("\nDestroying timer.");
        }
    }
    
    class StatusChecker
    {
        int invokeCount, maxCount;
    
        public StatusChecker(int count)
        {
            invokeCount  = 0;
            maxCount = count;
        }
    
        // This method is called by the timer delegate.
        public void CheckStatus(Object stateInfo)
        {
            AutoResetEvent autoEvent = (AutoResetEvent)stateInfo;
            Console.WriteLine("{0} Checking status {1,2}.", 
                DateTime.Now.ToString("h:mm:ss.fff"), 
                (++invokeCount).ToString());
    
            if(invokeCount == maxCount)
            {
                // Reset the counter and signal Main.
                invokeCount  = 0;
                autoEvent.Set();
            }
        }
    }
