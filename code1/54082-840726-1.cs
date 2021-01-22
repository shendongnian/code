    public void CallWithLogTiming (Action theAction)
    {
      Logger logger = new Logger();
      System.Diagnostics.Stopwatch stopWatch = new System.Diagnostics.Stopwatch();
      logger.LogInformation("Calling SomeObject.SomeMethod at " + DateTime.Now.ToString());
      stopWatch.Start();
    // This is the method I'm interested in.
      theAction();
    
      stopWatch.Stop();
      logger.LogInformation("SomeObject.SomeMethod returned at " + DateTime.Now.ToString());
      logger.LogInformation("SomeObject.SomeMethod took " + stopWatch.ElapsedMilliseconds + " milliseconds.");
    }
