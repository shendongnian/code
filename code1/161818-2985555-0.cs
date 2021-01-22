    public double Initial
    {
        get { return GetInitial(); }
        set { SetInitial(value); }
    }
    
    protected virtual void SetInitial(double value)
    {
        Count = 1;
    }
    protected abstract double GetInitial();
