    XmlElement SerializeToElement(Type t, object obj)
    {
        XmlSerializer ser = new XmlSerializer(t);
        StringWriter sw = new StringWriter();
        using (XmlWriter writer = XmlWriter.Create(sw, settings))
            ser.Serialize(writer, obj);
        string val  = sw.ToString();
        
        XmlDocument doc = new XmlDocument();
        doc.LoadXml(xmlString);
        return (XmlElement)doc.DocumentElement;
    }
