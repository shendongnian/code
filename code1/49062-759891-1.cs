    private XmlSchemaType elementType;
    // ...
    private XmlSchemaType type;
    // ...
    [XmlIgnore]
    public XmlSchemaType ElementSchemaType
    {
        get
        {
            return this.elementType;
        }
    }
    // ...
    [XmlElement("complexType", typeof(XmlSchemaComplexType)), XmlElement("simpleType", typeof(XmlSchemaSimpleType))]
    public XmlSchemaType SchemaType
    {
        get
        {
            return this.type;
        }
        set
        {
            this.type = value;
        }
    }
    // ...
    internal void SetElementType(XmlSchemaType value)
    {
        this.elementType = value;
    }
