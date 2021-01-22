    var settings = new XmlWriterSettings();
    settings.Indent = true;
    using (var writer = XmlWriter.Create(outputStream, settings))
    {
        writer.WriteDocType("html", "-//W3C//DTD XHTML 1.0 Transitional//EN", "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd", null);
        writer.WriteStartElement("html");
        writer.WriteStartElement("body");
        writer.WriteStartElement("b");
        writer.WriteValue("Test");
        writer.WriteEndElement();
        writer.WriteEndElement();
        writer.WriteEndElement();
    }
