    [XmlArrayItem("Address", IsNullable=false)]
    public string[] SendTo
    {
        get
        {
            return this.sendToField;
        }
        set
        {
            this.sendToField = value;
        }
    }
 
