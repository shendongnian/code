        [XmlRoot("XmlObject")]
    public class XmlObject
    {
        [XmlElement("A")]
        public string A { get; set; }
        [XmlElement("B")]
        public string B { get; set; }
        [XmlElement("listitems")]
        public List<Item> listitems { get; set; }
    }
    public class Item : IXmlSerializable
    {
        [XmlElement("C")]
        public string C { get; set; }
        [XmlElement("D")]
        public string D { get; set; }
        #region IXmlSerializable Members
        public System.Xml.Schema.XmlSchema GetSchema()
        {
            throw new NotImplementedException();
        }
        public void ReadXml(System.Xml.XmlReader reader)
        {
            this.C = reader.ReadElementString();
            this.D = reader.ReadElementString();
        }
        public void WriteXml(System.Xml.XmlWriter writer)
        {
            writer.WriteElementString("C", this.C);
            writer.WriteElementString("D", this.D);
        }
        #endregion
    }
