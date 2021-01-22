    private object _exclusiveAccessLock = new object();
    public void Populate(bool reload)
    {
        lock (_exclusiveAccessLock)
        {
             // start the job
        }
    }
    
