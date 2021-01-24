    public MainWindow()
    {
        TelemetryConfiguration config = TelemetryConfiguration.CreateDefault();
        config.InstrumentationKey = "954f17ff-47ee-4aa1-a03b-bf0b1a33dbaf";
        config.TelemetryChannel = new PersistenceChannel();
        config.TelemetryChannel.DeveloperMode = Debugger.IsAttached;
        telemetryClient = new TelemetryClient(config);
        telemetryClient.Context.User.Id = Environment.UserName;
        telemetryClient.Context.Session.Id = Guid.NewGuid().ToString();
        InitializeComponent();
    }
