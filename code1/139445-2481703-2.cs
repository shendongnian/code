    public void AppendElement()
    {
        XDocument doc;
        using(MemoryStream stream = GetXml())
        {
            using(var sr = new StreamReader(stream))
            {
                doc = XDocument.Load(sr);
            }
        }
        if(doc.Root != null)
        {
            doc.Root.Add(new XElement("Whatever"));
        }
    }
    private static MemoryStream GetXml()
    {
        var settings = new XmlWriterSettings {Indent = true};
        var memoryStream = new MemoryStream();
        using (XmlWriter writer = XmlWriter.Create(memoryStream, settings))
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
        return memoryStream;
    }
