    private static bool HasAppStarted = false;
    private readonly static object _syncObject = new object();
    
    public void Init(HttpApplication context)
    {
        if (!HasAppStarted)
        {
            lock (_syncObject)
            {
                if (!HasAppStarted)
                {
                    // Run application StartUp code here
    
                    HasAppStarted = true;
                }
            }
        }
    }
