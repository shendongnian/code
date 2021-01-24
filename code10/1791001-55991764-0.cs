    using Pose;
    
    Shim dateTimeShim = Shim.Replace(() => DateTime.Now).With(() => new DateTime(2004, 4, 4));
    
    // This block executes immediately
    PoseContext.Isolate(() =>
    {
        // All code that executes within this block
        // is isolated and shimmed methods are replaced
    
        // Outputs "4/4/04 12:00:00 AM"
        Console.WriteLine(DateTime.Now);
    
    }, dateTimeShim);
