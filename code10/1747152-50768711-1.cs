    public double T                 
    {
        get { return T; }
        set
        {
            Temperaure = value;
            initialize(Temperaure);
        }
    }
