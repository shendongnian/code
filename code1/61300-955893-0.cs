    public void WriteXml(XmlWriter writer)
    {
        writer.WriteStartElement("XmlSerializable");
        writer.WriteElementString("Integer", Integer.ToString());
        writer.WriteStartElement("OtherList");
        writer.WriteAttributeString("count", OtherList.Count.ToString());
        var otherSer = new XmlSerializer(typeof(OtherClass));
        foreach (var other in OtherList)
        {
            otherSer.Serialize(writer, other);
        }
        writer.WriteEndElement();
        writer.WriteEndElement();
    }
    public void ReadXml(XmlReader reader)
    {
        reader.ReadStartElement("XmlSerializable");
        
        reader.ReadStartElement("Integer");
        Integer = reader.ReadElementContentAsInt();
        reader.ReadEndElement();
        reader.ReadStartElement("OtherList");
        reader.MoveToAttribute("count");
        int count = int.Parse(reader.Value);
        var otherSer = new XmlSerializer(typeof (OtherClass));
        for (int i=0; i<count; i++)
        {
            var other = (OtherClass) otherSer.Deserialize(reader);
            OtherList.Add(other);
        }
        reader.ReadEndElement();
        reader.ReadEndElement();
    }
