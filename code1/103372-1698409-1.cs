    static Timer timer;
    
    public void Start()
    {
        var callback = new TimerCallback(DoSomething);
        timer = new Timer(callback, null, 0, Timeout.Infinite);
    }
    
    public void DoSomething()
    {
          try
          {
               // my processing code
          }
          finally
          {
              timer.Change(10000, Timeout.Infinite);
          }
    }
