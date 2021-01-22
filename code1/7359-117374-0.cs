    [XmlIgnore]
    public MyThing MyThing { get; set; }
    [XmlElement("MyThing")]
    private string MyThingForSerialization
    {
        get { return //convert MyThing to string; }
        set { MyThing = //convert string to MyThing; }
    }
