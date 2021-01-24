    // Create a 5 seconds timer 
        timer = new System.Timers.Timer(5000);
    
        // Hook up the Elapsed event for the timer.
        timer.Elapsed += OnTimedEvent;
    
        timer.Enabled = true;
    
    
    ...
    
    private static void OnTimedEvent(object source, ElapsedEventArgs e)
    {
        // Change  your bool val to false
    }
