    public void ConnectDataProvider()
        {
            timer = new Timer(new TimerCallback(tCallback), null, 0, Timeout.Infinite);            
        }
    private void tCallback(object state)
        {
            timer.Dispose();
            // time consuming task
            WriteData();
            timer = new Timer(new TimerCallback(tCallback), null, 5000, Timeout.Infinite);
        }
