    private double t;
    public double T                 
    {
        get { return t; }
        set 
        {    
            t = value;
            initialize(t);
        }
    }
