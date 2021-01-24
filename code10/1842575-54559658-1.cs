    public btnDatabaseStatus()
    {
        InitializeComponent();
        var timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(5) };
        timer.Tick += (s, e) => IsDbConnected = Dbs[0].IsConnected;
        timer.Start();
    }
