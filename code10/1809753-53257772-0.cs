    public class MyString : IXmlSerializable
    {
        string _xmlString;
        public XmlSchema GetSchema()
        {
            return null;
        }
    
        public void ReadXml(XmlReader reader)
        {
            reader.MoveToContent();
    
            Boolean isEmptyElement = reader.IsEmptyElement;
            if (!isEmptyElement)
            {
                _xmlString = reader.ReadInnerXml();
            }
        }
    
        public void WriteXml(XmlWriter writer)
        {
            writer.WriteString(_xmlString);
        }
    }
