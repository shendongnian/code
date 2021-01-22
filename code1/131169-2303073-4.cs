	private System.Timers.Timer timer;
	private ParameterlessVoid refreshMethod;
    private delegate void ParameterlessVoid();
	// Add these four lines to the constructor
    this.timer = new System.Timers.Timer(1000 / 20);  // 20 times per second
	this.timer.AutoReset = true;
    this.timer.Elapsed += this.HandleTimerElapsed;
	this.refreshMethod = new ParameterlessVoid(this.Refresh);
	private void HandleTimerElapsed(object sender, EventArgs e)
	{
		this.RefreshBuffer();
		this.Invoke(this.refreshMethod);
	}
	
	private void Start()
	{
		this.startTime = System.Environment.TickCount;
        this.timer.Start();
	}
