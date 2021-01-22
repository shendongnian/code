    [System.Xml.Serialization.XmlArrayAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    [System.Xml.Serialization.XmlArrayItemAttribute("ATTRIBUTES", typeof(DocumentAttributes), Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = false)]
    public DocumentAttributeCollection Document
    {
        get { return _documentField; }
        set { _documentField = value; }
    }
