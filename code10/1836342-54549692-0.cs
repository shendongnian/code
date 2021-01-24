        protected override void OnStart(string[] args)
        {
            timer = new System.Timers.Timer();                                        
            timer.Interval = 36000;                                                   // that fires every hour    
            timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed);    //calling the elapse event when the timer elapses
            timer.AutoReset = true;                                                   // AutoReset is set to true as we want the timer to fire 24x7 so that the elapse event is executed only at the requried time  
            timer.Enabled = true;                                                                                                   
        }
        protected void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)       //everytime the elapse event occurs the TimeCheck method will be called 
        {
            TimeCheck();    
        }
        public void TimeCheck()    //method to check if the current time is the time we want the archiving to occur
        {
           
            var dt = DateTime.Now.Hour;
            if(dt==21)
            {
                Archivefile();
            }
        }
