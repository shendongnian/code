    static void Main()
    {
        XmlWriterSettings settings = new XmlWriterSettings();
        settings.Indent = true;        
        StringBuilder builder = new StringBuilder();
        using (XmlWriter writer = XmlWriter.Create(builder, settings))
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
        Console.WriteLine(builder);
    }
