        // Create a timer with a two second interval.
        var aTimer = new System.Timers.Timer(2000);
        // Hook up the Elapsed event for the timer. 
        aTimer.Elapsed += OnTimedEvent // Name this whatever you want and put code here;
        aTimer.AutoReset = true;
        aTimer.Enabled = true;
