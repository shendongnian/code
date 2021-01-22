    protected TimeSpan myTimeout;
    public string MyTimeout 
    { 
        get { return myTimeout.ToString(); } 
        set { myTimeout = TimeSpan.Parse(value); }
    }
