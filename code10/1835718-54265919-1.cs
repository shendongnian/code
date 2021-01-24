    private Timer _timer;
    private Label _label;
    private int _elapsedSeconds;
    public Form1()
    {
    	_timer = new Timer
    	{
    		Interval = 1000,
    		Enabled = true
    	};
    	_timer.Tick += (sender, args) =>
    	{
    		_elapsedSeconds++;
            TimeSpan time = TimeSpan.FromSeconds(_elapsedSeconds);
            _label.Text = time.ToString(@"hh\:mm\:ss");
    	};
    
    	_label = new Label();
    
    	Controls.Add(_label);
    }
