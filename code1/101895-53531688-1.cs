	TimeTrialManager ttm;
	private void Form1_Load(object sender, EventArgs e)
	{
		ttm = new TimeTrialManager("TestTime");
		if (!ttm.expiryHasBeenStored()) ttm.setExpiryDate(30); // Expires in 30 days time
	}
	
	private void timer1_Tick(object sender, EventArgs e)
	{
		if (ttm.trialHasExpired()) { MessageBox.Show("Trial over! :("); Environment.Exit(0); }
	}
