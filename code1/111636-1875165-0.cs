    public class TestSoapHeaderTypeValuePair : IXmlSerializable
    {
        private string _type;
        private string _value;
    
        public TestSoapHeaderTypeValuePair(string type, string value)
        {
            Type = type;
            Value = value;
        }
    
        public TestSoapHeaderTypeValuePair() { }
    
        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }
    
        public string Value
        {
            get { return _value; }
            set { _value = value; }
        }
    
        #region IXmlSerializable Members
    
        System.Xml.Schema.XmlSchema IXmlSerializable.GetSchema()
        {
            return null;
        }
    
        void IXmlSerializable.ReadXml(System.Xml.XmlReader reader)
        {
            throw new NotImplementedException();
        }
    
        void IXmlSerializable.WriteXml(System.Xml.XmlWriter writer)
        {
            writer.WriteAttributeString("ex", "type", "http://www.example.com/namespace", Type);
            writer.WriteString(Value);
        }
    
        #endregion
    }
