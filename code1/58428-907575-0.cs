    XmlWriterSettings settings = new XmlWriterSettings();
    settings.Encoding = Encoding.UTF8;
    settings.Indent = true;
    using (XmlWriter writer = XmlWriter.Create(@"c:\path\file.xml", settings))
    {
    
        writer.WriteStartElement("pages");
    
        for (int i = 1; i < 5; i++)
        {
            writer.WriteStartElement("page");
            writer.WriteAttributeString("name", "Page Name " + i.ToString());
            writer.WriteAttributeString("url", string.Format("/page-{0}/", i));
            writer.WriteEndElement(); // page
        }
        writer.WriteEndElement(); // pages
    }
