    private string _testVariable;
    
    public string MyProperty
    {
        get { return _testVariable;}
        set {_testVariable = value;}
    }
    
    -or-
    
    public string MyProperty { get; set; }
