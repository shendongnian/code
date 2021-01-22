    Program.MicroTimer microTimer = new Program.MicroTimer();
    microTimer.MicroTimerElapsed += new Program.MicroTimer.MicroTimerElapsedEventHandler(OnTimedEvent);
    microTimer.Interval = 1000; // Call micro timer every 1000µs (1ms)
    
    // Can choose to ignore event if late by Xµs (by default will try to catch up)
    // microTimer.IgnoreEventIfLateBy = 500; // 500µs (0.5ms)
    microTimer.Enabled = true; // Start timer
    System.Threading.Thread.Sleep(2000);
    microTimer.Enabled = false;
