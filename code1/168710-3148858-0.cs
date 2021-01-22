    if(IsConsole)
       ExecuteTheProcess();
    else
    {
       ServiceBase[] servicesToRun = { mew MyService(); }
       ServiceBase.Run(servicesToRun);
    }
