    class Person : IXmlSerializable
    {
        #region IXmlSerializable Members
        public System.Xml.Schema.XmlSchema GetSchema()
        {
            // Provide Schema
            return null;
        }
        public void ReadXml(System.Xml.XmlReader reader)
        {
            // Read XML into Object
        }
        public void WriteXml(System.Xml.XmlWriter writer)
        {
            // Write XML here
        }
        #endregion
    }
