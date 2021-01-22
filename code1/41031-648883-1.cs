    void onButtonClick(object sender, EventArgs e)
    {
        Delay(1000, (o, e) => MessageBox.Show("Test"));
    }
    static void Delay(int ms, EventHandler action)
    {
    	var tmp = new Timer {Interval = ms};
        tmp.Tick += new EventHandler((o, e) => tmp.Enabled = false);
        tmp.Tick += action;
        tmp.Enabled = true;
    }
