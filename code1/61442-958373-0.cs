    private static void WriteProperty(XmlWriter writer, string name, string type, string value)
    {
        writer.WriteStartElement("Property");
        writer.WriteAttributeString("name", name);
        writer.WriteAttributeString("type", type);
        writer.WriteCData(value);
        writer.WriteEndElement();
    
    }
    
    // call the method from your code
    XPathExpression query = xPathNavigator.Compile(xpath);    
    XPathNavigator node = xPathNavigator.SelectSingleNode(query.Expression, xmlNamespaceManager);
    using (XmlWriter writer = node.AppendChild())
    {
        WriteProperty(writer, "someName", "String", "someValue");
    }
