    if(IsConsole)
       ExecuteTheProcess();
    else
    {
       ServiceBase[] servicesToRun = { new MyService(); }
       ServiceBase.Run(servicesToRun);
    }
