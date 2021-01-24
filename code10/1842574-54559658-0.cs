    public btnDatabaseStatus()
    {
        InitializeComponent();
        var timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(5) };
        timer.Tick += OnTimerTick;
        timer.Start();
    }
    private void OnTimerTick(object sender, EventArgs e)
    {
        IsDbConnected = Dbs[0].IsConnected;
    }
