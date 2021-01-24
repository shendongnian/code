     [XmlIgnore]
    public DateTime FromDateTime
    {
        get { return fromDateTime; }
        set
        {
            fromDateTime = value;
        }
    }
    [XmlElement]
    public int FromDateTimeCal
    {
        get
        {
            return fromDateTime.Subtract(DateTime.Today).Days;
        }
        set
        {
            fromDateTime = DateTime.Today.AddDays(value);
        }
    }
