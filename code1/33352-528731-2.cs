    static readonly DateTime epoch = new DateTime(1970, 1, 1);
    static long SerializeDateTime(DateTime value)
    {
        return (long)((value - epoch).TotalSeconds);
    }
    static DateTime DeserializeDateTime(long value)
    {
        return epoch.AddSeconds(value);
    }
    [XmlIgnore]
    public DateTime CreateDate { get; set; }
    [XmlElement("created"), Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public long CreateDateInt64 {
        get {return SerializeDateTime(CreateDate);}
        set {CreateDate = DeserializeDateTime(value);}
    }
