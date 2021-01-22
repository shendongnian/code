    class ExampleBaseClass : IXmlSerializable { 
        public XmlDocument xmlDocument { get; set; }
        public XmlSchema GetSchema()
        {
            return null;
        }
        public void ReadXml(XmlReader reader)
        {
            xmlDocument.Load(reader);
        }
        public void WriteXml(XmlWriter writer)
        {
            xmlDocument.WriteTo(writer);
        }
    }
