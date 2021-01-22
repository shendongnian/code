    public class CDataField : IXmlSerializable
        {
            private string elementName;
            private string elementValue;
    
            public CDataField(string elementName, string elementValue)
            {
                this.elementName = elementName;
                this.elementValue = elementValue;
            }
    
            public XmlSchema GetSchema()
            {
                return null;
            }
    
            public void WriteXml(XmlWriter w)
            {
                w.WriteStartElement(this.elementName);
                w.WriteCData(this.elementValue);
                w.WriteEndElement();
            }
    
            public void ReadXml(XmlReader r)
            {                      
                throw new NotImplementedException("This method has not been implemented");
            }
        }
