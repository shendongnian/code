    private DispatcherTimer dispatcherTimer;
    public FORM_ENTRY()
    {
        InitializeComponent();
        LabelWelcome.Text = "Welcome! Welkom! Selamat Datang! Wilkommen!";
        LabelCheckedIn.Visible = false;
        LabelEnjoy.Visible = false;
		
		// Initialize Dispatcher
		dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
		dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
		// Five seconds delay
		dispatcherTimer.Interval = new TimeSpan(0, 0, 5);
		dispatcherTimer.Start();
    }
	private void dispatcherTimer_Tick(object sender, EventArgs e)
	{
		System.Text.StringBuilder sb = new System.Text.StringBuilder(LabelWelcome.Text);		
		char ch = sb[sb.Length - 1];
		sb.Remove(sb.Length - 1, 1);
		sb.Insert(0, ch);
		LabelWelcome.Text = sb.ToString();
	}
    private void ButtonExit_Click(object sender, EventArgs e)
    {
        this.Close();
    }
