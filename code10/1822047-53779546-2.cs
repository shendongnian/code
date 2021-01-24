    public class Person : IXmlSerializable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Address Address { get; set; }
        public XmlSchema GetSchema() { throw new NotImplementedException(); }
        public void ReadXml(XmlReader reader)
        {
            while (reader.Read())
            {
                if (reader.Name == "attr" && reader.GetAttribute("n") == "id")
                    Id = Convert.ToInt32(reader.ReadInnerXml());
                if (reader.Name == "attr" && reader.GetAttribute("n") == "name")
                    Name = reader.ReadInnerXml();
                if (reader.Name == "attr" && reader.GetAttribute("n") == "street")
                    Address = new Address { Street = reader.ReadInnerXml() };
            }
        }
        public void WriteXml(XmlWriter writer)
        {
            //Start "struct"
            writer.WriteStartElement("struct");
            writer.WriteAttributeString("n", "People");
            writer.WriteStartElement("attr");
            writer.WriteAttributeString("n", "id");
            writer.WriteString(Id.ToString());
            writer.WriteEndElement();
            writer.WriteStartElement("attr");
            writer.WriteAttributeString("n", "name");
            writer.WriteString(Name.ToString());
            writer.WriteEndElement();
            //Start inner "struct"
            writer.WriteStartElement("struct");
            writer.WriteAttributeString("n", "Address");
            writer.WriteStartElement("attr");
            writer.WriteAttributeString("n", "street");
            writer.WriteString(Address.Street.ToString());
            writer.WriteEndElement();
            //End inner "struct"
            writer.WriteEndElement();
            //End "struct"
            writer.WriteEndElement();
        }
    }
