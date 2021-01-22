    [XmlIgnore]
    public Nullable<DateTime> MyDateTime { get; set }
    [XmlElement(ElementName = "MyDateTime", IsNullable = false)]
    public string MyDateTimeXml
    {
        get
        {
            if (MyDateTime.HasValue)
                return XmlConvert.ToString(MyDateTime.Value, XmlDateTimeSerializationMode.Unspecified);
            else
                return null;
        }
        set
        {
            if (value != null)
                MyDateTime = XmlConvert.ToDateTime(value, XmlDateTimeSerializationMode.Unspecified);
            else
                MyDateTime = null;
        }
    }
