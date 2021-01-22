    public XmlAttributes(ICustomAttributeProvider provider)
    {
        this.xmlElements = new XmlElementAttributes();
        this.xmlArrayItems = new XmlArrayItemAttributes();
        this.xmlAnyElements = new XmlAnyElementAttributes();
        object[] customAttributes = provider.GetCustomAttributes(false);
        ...
    }
