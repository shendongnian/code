    public string MyProperty // not read-only
    {
        get { return myPropertyBacking; }
        set { myPropertyBacking = value; }
    }
    
    public string MyProperty // read-only
    {
        get { return myPropertyBacking; }
    }
