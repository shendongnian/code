    public void AppendElement()
    {
        XDocument doc = GetXml();
        if(doc.Root != null)
        {
            doc.Root.Add(new XElement("Whatever"));
        }
    }
    private static XDocument GetXml()
    {
        var doc = new XDocument();
        using (XmlWriter writer = doc.CreateWriter())
        {
            writer.WriteStartDocument();
            writer.WriteStartElement("root");
            writer.WriteStartElement("element");
            writer.WriteString("content");
            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Flush();
        }
        return doc;
    }
