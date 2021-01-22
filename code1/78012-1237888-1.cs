    Timer Clock=new Timer();
    Clock.Interval=5*60*1000;
    Clock.Start();
    Clock.Tick+=new EventHandler(Timer_Tick);
    
     public void Timer_Tick(object sender,EventArgs eArgs)
     {
        System.Windows.Forms.Application.Exit()
     }
