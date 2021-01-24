    bool suspendExecution = false;
    public void Initialize()
    {
        BaseWorkerTask = Task.Run(() =>
        {
            BaseWorker(ref suspendExecution);
        });
    }
    
    public void BaseWorker(ref bool suspend)
    {
        while (WaitServerResponse())
        {
             if (suspend)
             {
                 while (suspend)
                 {
                     Thread.Sleep(1000);
                 }
             }
             DoSomethingElse();
         }
    }
