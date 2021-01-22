    Hardware.TeliaModem _modem;
    public Form1()
    {
        InitializeComponent();
        _modem = new Hardware.TeliaModem(this);
        _modem.OnNewSMS += new Hardware.TeliaModem.NewSmsHandler(ProcessNewSMS);
            _timer.Interval = 1000; // milliseconds
            _timer.Tick += new EventHandler(OnTimerTick);
            _timer.Start();
    }
