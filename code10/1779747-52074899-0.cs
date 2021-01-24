    Use System.Windows.Forms.Timer.
    
    private Timer timer1; 
    public void InitTimer()
    {
        timer1 = new Timer();
        timer1.Tick += new EventHandler(timer1_Tick);
        timer1.Interval = 10000; // 10 seconds / 10000 MillSecs
        timer1.Start();
    }
    
    private void timer1_Tick(object sender, EventArgs e)
    {
        isonline();
    }
