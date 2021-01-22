    class OneTimer
        {
            // Created by Roy Feintuch 2009
            // Basically we wrap a timer object in order to send itself as a context in order to dispose it after the cb invocation finished. This solves the problem of timer being GCed because going out of context
            public static void DoOneTime(ThreadStart cb, TimeSpan dueTime)
            {
                var td = new TimerDisposer();
                var timer = new Timer(myTdToKill =>
                {
                    try
                    {
                        cb();
                    }
                    catch (Exception ex)
                    {
                        Trace.WriteLine(string.Format("[DoOneTime] Error occured while invoking delegate. {0}", ex), "[OneTimer]");
                    }
                    finally
                    {
                        ((TimerDisposer)myTdToKill).InternalTimer.Dispose();
                    }
                },
                            td, dueTime, TimeSpan.FromMilliseconds(-1));
    
                td.InternalTimer = timer;
            }
        }
    
        class TimerDisposer
        {
            public Timer InternalTimer { get; set; }
        }
