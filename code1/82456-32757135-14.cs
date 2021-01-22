    public string MyTestProperty
    {
        get { return base.TestProperty; }
        set { changeProperty(base.TestProperty, (x) => { base.TestProperty = x; }, value); }
    }
