    Dictionary<string,object> mPropertyBackingStore = new Dictionary<string,object> ();
    
    public PropertyThing MyPropertyThing
    {
        get { return mPropertyBackingStore["MyPropertyThing"] as PropertyThing; }
        set { mPropertyBackingStore["MyPropertyThing"] = value; }
    }
