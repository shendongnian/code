    public void SetTimeout(EventHandler doWork, int delayMS)
    {
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        timer.Interval = delayMS; 
         
        timer.Tick += delegate(object s, EventArgs args) { timer.Stop(); };
        timer.Tick += doWork;
        timer.Start();
    }
