    private EventHandler _explicitEvent;
    public event EventHandler ExplicitEvent {
       add { _explicitEvent += value; } 
       remove { _explicitEvent -= value; }
    }
    
    private double seconds; 
    public double Hours
    {
        get { return seconds / 3600; }
        set { seconds = value * 3600; }
    }
