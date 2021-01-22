    public class SubLibrary : IXmlSerializable 
    {
        private string str = "Hello World";
        public SubLibrary()
        {
        }
        public string GetValue()
        {
            return str;
        }
        public XmlSchema GetSchema()
        {
            return null;
        }
        public void ReadXml(XmlReader reader)
        {
            //...
        }
        public void WriteXml(XmlWriter writer)
        {
            //...
        }
    }
