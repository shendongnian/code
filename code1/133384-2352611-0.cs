        using (XmlWriter writer = XmlWriter.Create(stream))
        {
            writer.WriteStartElement("logentry");
            writer.WriteAttributeString("t", DateTime.Now.ToString());
            writer.WriteString("Something to log.");
            writer.WriteEndElement();
        }
