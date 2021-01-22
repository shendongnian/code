    Timer myTimer = new Timer(); // Windows.Forms Timer
    public void addEvent(EventHandler ev)
    {
        myTimer.Tick += ev;
    }
    
    public void removeEvent(EventHandler ev)
    {
        myTimer.Tick -= ev;
    }
