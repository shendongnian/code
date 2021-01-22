    Timer ProcessTimer = new Timer(new TimerCallback(ProcessRandomTask), null, 0,Timeout.Infinite);
    
    
    private void ProcessRandomTask(object data)
    {
     //Do work
      lock(ProcessTime)
      {
           //change timer
           ProcessTimer.Change(GetNewTime(), Timeout.Infinite);
      }
    }
