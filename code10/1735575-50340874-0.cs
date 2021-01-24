    private void page_Load(object sender, EventArgs e)
    {
        Timer timer = new Timer();
        timer.Interval = (30 * 1000); // 30 secs
        timer.Tick += new EventHandler(timer_event);
        timer.Start();
    }
    
    private void timer_event(object sender, EventArgs e)
    {
       //refresh here...
    }
