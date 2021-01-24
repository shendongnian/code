    DateTime lastExecutionDate = DateTime.UtcNow;
    void Update()
    {
        var tomorrow = DateTime.Now.AddDays(1).ToShortDateString();
        var now = DateTime.UtcNow;
    
        if (lastExecutionDate.Day < now.Day)
        {
            lastExecutionDate = now;
            // this code will be called as close to midnight as unity allows.
        }
    }
