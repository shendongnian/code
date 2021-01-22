            public partial class Service : ServiceBase{
            
            System.Timers.Timer timer;
            
    
            public Service()
            {
    
    		timer = new System.Timers.Timer();
    		//When autoreset is True there are reentrancy problme 
    		timer.AutoReset = false;
    
    
    		timer.Elapsed += new System.Timers.ElapsedEventHandler(DoStuff);
    	}
    	
    	
    	 private void DoStuff(object sender, System.Timers.ElapsedEventArgs e)
    	 {
    	 
    	 	Collection stuff = GetData();
    	 	LastChecked = DateTime.Now;
    	 	
    		foreach (Object item in stuff)
    		{
    			try
                       	{
                       		item.Dosomthing()
                       	}
                       	catch (System.Exception ex)
    			{
    				this.EventLog.Source = "SomeService";
    				this.EventLog.WriteEntry(ex.ToString());
    				this.Stop();
    		}
    			
    			    	
    		TimeSpan ts = DateTime.Now.Subtract(LastChecked);
    		TimeSpan MaxWaitTime = TimeSpan.FromMinutes(5);
    
    
    		if (MaxWaitTime.Subtract(ts).CompareTo(TimeSpan.Zero) > -1)
    			timer.Interval = MaxWaitTime.Subtract(ts).Milliseconds;
    		else
    			timer.Interval = 1;
    
    		timer.Start();
    
    	
    	 
    	 
    	 
    	 }
    	 
            protected override void OnPause()
    	 {
    	     
    	     base.OnPause();
    	     this.timer.Stop();
    	 }
    
    	 protected override void OnContinue()
    	 {
    	     base.OnContinue();
    	     this.timer.Interval = 1;
    	     this.timer.Start();
    	 }
    
    	 protected override void OnStop()
    	 {
    	    
    	     base.OnStop();
    	     this.timer.Stop();
    	 }
    
    
    	 protected override void OnStart(string[] args)
    	 {
    	    foreach (string arg in args)
            {
                if (arg == "DEBUG_SERVICE")
                        DebugMode();
         
            }
    
    	     #if DEBUG
    			 DebugMode();
    	     #endif
    
    	     timer.Interval = 1;
    	     timer.Start();
    
            }
        private static void DebugMode()
        {
            Debugger.Break();
        }
    	
               
               
     }
