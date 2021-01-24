    public static void WriteXml(Person person, string path)
    {
        using (XmlWriter writer = XmlWriter.Create(path))
        {
            //Start "struct"
            writer.WriteStartElement("struct");
            writer.WriteAttributeString("n", "People");
            writer.WriteStartElement("attr");
            writer.WriteAttributeString("n", "id");
            writer.WriteString(person.Id.ToString());
            writer.WriteEndElement();
            writer.WriteStartElement("attr");
            writer.WriteAttributeString("n", "name");
            writer.WriteString(person.Name.ToString());
            writer.WriteEndElement();
            //Start inner "struct"
            writer.WriteStartElement("struct");
            writer.WriteAttributeString("n", "Address");
            writer.WriteStartElement("attr");
            writer.WriteAttributeString("n", "street");
            writer.WriteString(person.Address.Street.ToString());
            writer.WriteEndElement();
            //End inner "struct"
            writer.WriteEndElement();
            //End "struct"
            writer.WriteEndElement();
        }
    }
