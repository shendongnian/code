        private static System.Timers.Timer EventTimer  = new System.Timers.Timer(1200);//Ticks
       EventTimer  .Elapsed += new System.Timers.ElapsedEventHandler(eventClp_Elapsed);
       EventTimer  .Start();
    
        private static void eventClp_Elapsed(object sender, System.Timers.ElapsedEventArgs e) {
                EventTimer.Stop();
        //do something
        //you can restart again
            }
