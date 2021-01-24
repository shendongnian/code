    Timer testTimer;
    
    public void initTimer()
    {
        testTimer = new Timer();
        testTimer.Tick += testTimer_tick ;
        testTimer.Interval = 1000; //timer interval in mili seconds;
        testTimer.Start();
    }
    public void testTimer_tick(object sender, EventArgs e)
    {    		
    	MyFunction(); // your function comes here    		
   	}
