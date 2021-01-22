    [XmlIgnore]
    public bool MyValue { get; set; }
    /// <summary>Get a value purely for serialization purposes</summary>
    [XmlElement("MyValue")]
    public string MyValueSerialize
    {
        get { return this.MyValue ? "1" : "0"; }
        set { this.MyValue = XmlConvert.ToBoolean(value); }
    }
