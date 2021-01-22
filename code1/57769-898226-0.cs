    void IXmlSerializable.WriteXml(System.Xml.XmlWriter writer)
    {
        // write xml decl and root elts here
        var s = new XmlSerializer(typeof(MySerializableType)); 
        s.Serialize(writer, MyList);
        // continue writing other elts to writer here
    }
