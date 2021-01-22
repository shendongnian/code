    #if debug
    
    // Do stuff
    if(!System.Diagnostics.Debugger.IsAttached)
    {
    System.Diagnostics.Debugger.Launch();
    }
    System.Diagnostics.Debugger.Break();
    
    #endif
