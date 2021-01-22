    // again, not valid C#:
    public string MyProp
    {
        get { return _MyProp;}
        set { _MyProp = value; }
    } = "initial value before being massaged or rejected by the set accessor.";
