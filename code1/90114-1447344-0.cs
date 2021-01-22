    public string Prop1
    {
        get { return dic["Prop1"]; }
        set { dic["Prop1"] = value; }
    }
    public string Prop2
    {
        get { return dic["Prop2"]; }
        set { dic["Prop2"] = value; }
    }
    
    private Dictionary<string, string> 
    public IEnumerable<KeyValuePair<string, string>> AllProps
    {
        get { return dic.GetEnumerator(); }
    }
