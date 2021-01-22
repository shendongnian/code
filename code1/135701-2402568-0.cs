    [XmlIgnore]
    public TimeSpan ScheduledTime
    {
        get;
        set;
    }
    
    [XmlElement("ScheduledTime", DataType="duration")]
    public string XmlScheduledTime
    {
        get { return XmlConvert.ToString(ScheduledTime); }
        set { ScheduledTime = XmlConvert.ToTimeSpan(value); }
    }
