    [...]
    public MainWindow()
    {
        InitializeComponent();
        DispatcherTimer LiveTime = new DispatcherTimer();
        LiveTime.Interval = TimeSpan.FromSeconds(1);
        LiveTime.Tick += timer_Tick;
        LiveTime.Start();
    }
    void timer_Tick(object sender, EventArgs e)
    {
        LiveTimeLabel.Content = DateTime.Now.ToString("HH:mm:ss");
    }
    [...]
