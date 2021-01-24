    [XmlIgnore]
    public System.DateTime Time
    {
        get { return this.time; }
        set { this.time = value; }
    }
    
    [System.Xml.Serialization.XmlElementAttribute(DataType = "time")]
    public string TimeString 
    {
    	get { return Time.ToString("yyyy-MM-dd"); }
        set { Time = DateTime.Parse(value); }
    }
