    // In some constructor or method that runs when the app starts.
    // 1st parameter is the callback to be run every iteration.
    // 2nd parameter is optional parameters for the callback.
    // 3rd parameter is telling the timer when to start.
    // 4th parameter is telling the timer how often to run.
    System.Threading.Timer timer = new System.Threading.Timer(new TimerCallback(TimerElapsed), null, new Timespan(0), new Timespan(24, 0, 0));
    
    // The callback, no inside the method used above.
    // This will run every 24 hours.
    private void TimerElapsed(object o)
    {
        // Do stuff.
    }
