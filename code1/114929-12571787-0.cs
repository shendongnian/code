    public static XmlElement SerializeToXmlElement(object o)
    {
        XmlDocument doc = new XmlDocument();
        
        using(XmlWriter writer = doc.CreateNavigator().AppendChild())
        {
            new XmlSerializer(o.GetType()).Serialize(writer, o);
        }
        
        return doc.DocumentElement;
    }
