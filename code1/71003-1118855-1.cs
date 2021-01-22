    [XmlIgnore]
    public DateTime DoNotSerialize {get;set;}
    
    public string ProxyDateTime {
        get {return DoNotSerialize.ToString("yyyymmdd");}
        set {DoNotSerialize = DateTime.Parse(value);}
    }
