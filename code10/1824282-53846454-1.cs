    System.Timers.Timer timer= new System.Timers.Timer(1000);
    
    private void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
    {
           if(timer.Interval!=30000 && DateTime.Now.Seconds % 30 == 0)
    	   {
    	   		timer.Stop();
    	   		timer.Interval = 30000;
    	   		timer.Start();
                DoWork();
    	   }
    	   else
    	   {
    	   	if(timer.Interval==30000)
                {
                    DoWork();
                }
    		}
    }
