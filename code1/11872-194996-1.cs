    XmlWriterSettings settings = new XmlWriterSettings();
    settings.Indent = true;
    settings.IndentChars = ("    ");
    using (XmlWriter writer = XmlWriter.Create("books.xml", settings))
    {
        // Write XML data.
        writer.WriteStartElement("book");
        writer.WriteElementString("price", "19.95");
        writer.WriteEndElement();
        writer.Flush();
    }
