    System.Timers.Timer Timer = new Timer();
    bool Moving;
    void init()
    {
      Timer.AutoReset = false;
      Timer.Elapsed += OnMoveTimerEvent;
      Moving = false;
    }
    void MainLoop()
    {
       //stuff
       if(should move)
       {
         timer.start();
       }
       if(should stop moving)
       {
         timer.stop();
       }
    }
    void OnMoveTimerEvent(object source, ElapsedEventArgs e)		
    {
      if (!Moving)
      {
        //start motor
        Timer.Interval = 500;
        Moving = true;
        Timer.Start();
      }
      else
      {
        //stop motor
        Moving = true;
        Timer.Interval = 2000;
        Timer.Start();
      }
    }
