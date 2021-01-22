    public DateTime DateField;
    
    [System.Xml.Serialization.XmlAttribute("DateField")]
    protected DateTime UtcDateField
    {
        get
        {
            //Convert DateField to UTC
        }
    
        set
        {
            DateField = //Convert value from UTC
        }
    }
