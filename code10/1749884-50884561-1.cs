    DateTime lastExecutionDate = DateTime.Utc;
    void Update()
    {
        var tomorrow = DateTime.Now.AddDays(1).ToShortDateString();
        var now = DateTime.Utc;
    
        if (lastExecutionDate.Day < now.Day)
        {
            lastExecutionDate = now;
            // this code will be called as close to midnight as unity allows.
        }
    }
