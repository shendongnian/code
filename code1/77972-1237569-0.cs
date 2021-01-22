    public class MyData : IXmlSerializable
    {
        public Nullable<DateTime> MyDateTime { get; set; }
        
        public void WriteXml(XmlWriter writer)
        {
            if (this.MyDateTime.HasValue)
            {
                writer.WriteStartElement("MyDateTime");
                writer.WriteValue((DateTime)this.MyDateTime);
                writer.WriteEndElement();
            }
        }
        
        public void ReadXml(XmlReader reader)
        {
            if (reader.ReadToDescendant("MyDateTime"))
            {
                this.MyDateTime = reader.ReadElementContentAsDateTime();
            }
        }
        
        public XmlSchema GetSchema()
        {
            return null;
        }
    }
