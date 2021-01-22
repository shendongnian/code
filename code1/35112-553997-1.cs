    public void addEvent(EventHandler ev)
    {
        myTimer.Tick += ev;
    }
    
    public void removeEvent(EventHandler ev)
    {
        myTimer.Tick -= ev;
    }
    
    addEvent(new EventHandler(...));
    removeEvent(new EventHandler(...));
