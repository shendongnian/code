    [XmlIgnore]
    public TimeSpan TimeSinceLastEvent
    {
        get { return m_TimeSinceLastEvent; }
        set { m_TimeSinceLastEvent = value; }
    }
    // XmlSerializer does not support TimeSpan, so use this property for serialization 
    // instead.
    [Browsable(false)]
    [XmlElement(DataType="duration", ElementName="TimeSinceLastEvent")]
    public string TimeSinceLastEventString
    {
        get 
        { 
            return XmlConvert.ToString(TimeSinceLastEvent); 
        }
        set 
        { 
            TimeSinceLastEvent = string.IsNullOrEmpty(value) ?
                TimeSpan.Zero : XmlConvert.ToTimeSpan(value); 
        }
    }
