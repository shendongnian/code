    Timer SomeTimer;
    void SomeMethod()
    {
        SomeTimer = new Timer();
    	SomeTimer.Tag = "myArgString"; // or struct, class, list, etc..
    	SomeTimer.Tick += new EventHandler(SomeTimer_Tick);
    	SomeTimer.Start();
    }
    
    void SomeTimer_Tick(object sender, EventArgs e)
    {
    	string s = ((Timer)sender).Tag; // SomeTimer.Tag
    }
