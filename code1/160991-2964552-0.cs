    protected override void OnStart(string[] args)
    {
    #if DEBUG
        while (!Debugger.IsAttached)      // Waiting until debugger is attached
        {
            RequestAdditionalTime(1000);  // Prevents the service from timeout
            Thread.Sleep(1000);           // Gives you time to attach the debugger   
        }
        RequestAdditionalTime(20000);     // for Debugging the OnStart method,
                                          // increase as needed to prevent timeouts
    #endif
        
        // here is your startup code with breakpoints
    } 
