     [XmlRoot("departments")]
     public class Departments : ConfigurationSection, IXmlSerializable
     {
        //Your code here..
        public XmlSchema GetSchema()
        {
            return this.GetSchema();
        }
        public void ReadXml(XmlReader reader)
        {
            this.DeserializeElement(reader, false);
        }
        public void WriteXml(XmlWriter writer)
        {
            this.SerializeElement(writer, false);
        }
     }
