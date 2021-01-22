    public Command CommandToRun_WithCheck
    {
        get
        {
            return new Command(() =>
            {
                // Code to run
            }, () =>
            {
                // Code to check to see if we can run 
                // Return true or false
            });
        }
    }
    public Command CommandToRun_NoCheck
    {
        get
        {
            return new Command(() =>
            {
                // Code to run
            });
        }
    }
