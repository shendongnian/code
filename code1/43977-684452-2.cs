    // Initialize timer as a one-shot
    Timer UpdateTimer = new Timer(UpdateCallback, null, 30000, Timeout.Infinite);
    
    void UpdateCallback(object state)
    {
        // do stuff here
        // re-enable the timer
        UpdateTimer.Change(30000, Timeout.Infinite);
    }
