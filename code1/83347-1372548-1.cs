    void StartTimer()
    {
        			
      shortIntervalTimer.Interval = 1000;
      mainIntervalTimer.Interval = 60000; 
        
      shortIntervalTimer.Tick += 
        new System.EventHandler(this.shortIntervalTimer_Tick);
      mainIntervalTimer.Tick += 
        new System.EventHandler(mainIntervalTimer_Tick);
        
      shortIntervalTimer.Start();
        			
    }
        
    private void shortIntervalTimer_Tick(object sender, System.EventArgs e)
    {
      if (DateTime.Now.Second == 0)
        {
          mainIntervalTimer.Start();
          shortIntervalTimer.Stop();
        }
    }
        
    private void mainIntervalTimer_Tick(object sender, System.EventArgs e)
    {
      // do what you need here //
    }
