    static void Main()
    {
      Thread workerThread = new Thread(new ParameterizedThreadStart(DoWork));
      workerThread.Start(Thread.CurrentContext);
    }
    
    void DoWork(object state)
    {
       ConnectDatabase();
    
       //do some work
    
       ((Context)state).DoCallBack(() => Thread.CurrentThread.CurrentUICulture = ...);
    }
