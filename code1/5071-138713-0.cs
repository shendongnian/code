    [XmlElement("item")]
    public myClass[] item
    {
        get { return this.privateList.ToArray(); }
    }
