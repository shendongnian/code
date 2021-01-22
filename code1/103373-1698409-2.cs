    static Timer timer;
    static object locker = new object();
    
    public void Start()
    {
        var callback = new TimerCallback(DoSomething);
        timer = new Timer(callback, null, 0, 10000);
    }
    
    public void DoSomething()
    {
          if (Monitor.TryEnter(locker))
          {
               try
               {
                   // my processing code
               }
               finally
               {
                   Monitor.Exit(locker);
               }
          }
    }
