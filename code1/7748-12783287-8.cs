    protected override void OnStart(string[] args)
    {
        #if DEBUG
           base.RequestAdditionalTime(600000); // 10 minutes timeout for startup
           Debugger.Launch(); // launch and attach debugger
        #endif
        MyInitOnstart(); // my individual initialization code for the service
        // allow the base class to perform any work it needs to do
        base.OnStart(args);
    }
