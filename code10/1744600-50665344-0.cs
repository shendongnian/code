    void Start()
    {
        dispatcherTimer = new DispatcherTimer();
        dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
        dispatcherTimer.Interval = TimeSpan.FromMilliseconds(1000);
        dispatcherTimer.Start();
    }
    dispatcherTimer_Tick(object sender, EventArgs e)
    {
        for (int i = 1; i < 3; i++)
        {
            SpawnTroop(i);
        }  
    }
   
