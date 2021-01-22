    [DataMember, XmlIgnore]
    public TimeSpan MyTimeoutValue { get; set; }
    [DataMember]
    public string MyTimeout
    {
        get { return MyTimeoutValue.ToString(); }
        set { MyTimeoutValue = TimeSpan.Parse(value); }
    }
