    public MainWindow()
    {
        InitializeComponent();
        _stateTracker.Configure(this)
            .IdentifyAs("MyMainWindow")
            .AddProperties(nameof(Height), nameof(Width), nameof(Left), nameof(Top), nameof(WindowState))
            .RegisterPersistTrigger(nameof(Closed))
            .Apply();
    }
