    private string _description;
    public Region(string description)
    {
        Check.Require(!string.IsNullOrEmpty(description));
        _description = description;
    }
    protected Region()
    {
    }
    [DomainSignature]
    public virtual string Description {
        get {return _description;} 
        set {_description = value;}
    }
