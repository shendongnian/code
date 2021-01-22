    public void Main()
    {
    
        var T = new System.Timers.Timer();
    
        T.Elapsed += CallBackFunction;
    
        var D = (DateTime.Today.AddDays(1).Date - DateTime.Now);
    
        T.Interval = D.TotalMilliseconds;
    
        T.Start();
    
    }
    
    private void CallBackFunction(object sender, System.Timers.ElapsedEventArgs e)
    {
        
        (sender as System.Timers.Timer).Interval = (DateTime.Today.AddDays(1).Date - DateTime.Now).TotalMilliseconds;
    
    }
