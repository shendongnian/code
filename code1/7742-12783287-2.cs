    protected override void OnStart(string[] args)
    {
        #if DEBUG
                    // request more time
                    base.RequestAdditionalTime(600 * 1000); // 10 minutes
                    Debugger.Launch();
        #endif
        // my initialization required
        MyInitOnstart();
        // call the base class so it has a chance
        // to perform any work it needs to
        base.OnStart(args);
    }
