    int c = 0;
    Timer tmr1 = new Timer()
    {
    	Interval = 100,
    	Enabled= false
    };
    tmr1.Tick += delegate
    {
    	c++;
    };
    
    // used to continously monitor the values of "c" and tmr1.Enabled
    Timer tmr2 = new Timer()
    {
    	Interval = 100,
    	Enabled = true
    };
    tmr2.Tick += delegate
    {
    	this.Text = string.Format("c={0}, tmr1.Enabled={1}", c, tmr1.Enabled.ToString());
    };
    
    button1.Click += delegate
    {
    	tmr1.Start();
    };
    button2.Click += delegate
    {
    	tmr1.Stop();
    };
