    [XmlIgnore]
    public MyEnum MyProperty { get; set; }
    
    [XmlElement("MyProperty")]
    public string MyPropertyAsString
    {
        get
        {
            return MyProperty.ToString();
        }
        set
        {
            MyProperty = (MyEnum)StringToEnum(value);
        }
    }
    
    public Enum StringToEnum(string stringValue)
    {
        // Manually convert the string to enum, ignoring unknown values
    }
