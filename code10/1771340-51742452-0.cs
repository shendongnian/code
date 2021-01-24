	public MainForm()
	{
		InitializeComponent();
		MessageBox.Show("Welcome");
		Observable
			.Timer(TimeSpan.FromMinutes(1.0))
			.ObserveOn(this)
			.Subscribe(x => MessageBox.Show("one minute left"));
		Observable
			.Timer(TimeSpan.FromMinutes(2.0))
			.ObserveOn(this)
			.Subscribe(x =>
			{
				MessageBox.Show("time over");
				Application.Exit();
			});
	}
