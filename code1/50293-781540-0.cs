    public bool CanSelect
    {
        get
        {
            return this.CanSelectCore();
        }
    }
    
    internal virtual bool CanSelectCore()
    {
        ...
    }
