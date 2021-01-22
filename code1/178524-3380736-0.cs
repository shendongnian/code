       // Declare at form class scope
       System.Windows.Forms.Timer myTimer = new System.Windows.Forms.Timer();
       // ...
       myTimer.Tick += new EventHandler(TimerEventProcessor);
       // Sets the timer interval to 120 seconds (2 minutes).
       myTimer.Interval = 120000;
       myTimer.Start();
