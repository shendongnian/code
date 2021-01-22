    [XmlIgnore]
    public DateTime DoNotSerialize {get;set;}
    
    public string ProxyDateTime {
        get {return DoNotSerialize.ToString("yyyyMMdd");}
        set {DoNotSerialize = DateTime.Parse(value);}
    }
