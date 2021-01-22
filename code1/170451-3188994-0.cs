    [XmlIgnore()]
    public DateTime Time { get; set; }
    
    [XmlElement(ElementName = "Time")]
    public string XmlTime
    {
        get { return XmlConvert.ToString(Time, XmlDateTimeSerializationMode.RoundtripKind); }
        set { Time = DateTimeOffset.Parse(value).DateTime; }
    }
