    [XmlIgnore]
    public MyThing MyThing { get; set; }
    [XmlElement("MyThing")]
    [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
    public string MyThingForSerialization
    {
        get { return //convert MyThing to string; }
        set { MyThing = //convert string to MyThing; }
    }
