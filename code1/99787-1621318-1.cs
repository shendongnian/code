    [XmlIgnore]
    public MyEnum MyProperty { get; set; }
    
    [XmlElement("MyProperty")]
    public string MyPropertyAsString
    {
        get
        {
            return EnumToString(MyProperty);
        }
        set
        {
            MyProperty = StringToEnum<MyEnum>(value);
        }
    }
    
    public T StringToEnum<T>(string stringValue)
    {
        // Manually convert the string to enum, ignoring unknown values
    }
    public string EnumToString<T>(T enumValue)
    {
        // Convert the enum to a string
    }
