    XmlWriterSettings settings = new XmlWriterSettings();
    settings.Indent = true;
    
    using (TempFileStream tfs = new TempFileStream(f => File.Move(f, filename))
    using (XmlWriter writer = XmlWriter.Create(tfs, settings))
    {
        writer.WriteStartDocument(true);
        writer.WriteStartElement("parentelement");
        writer.WriteEndElement();
        writer.WriteEndDocument();
    }
