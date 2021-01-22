    public partial class GetCurrentTimeResponse : 
        System.Xml.Serialization.IXmlSerializable
    {
        public XmlSchema GetSchema() { return null; }
    
        public void ReadXml(XmlReader reader) {
            // Fill the TimeStamp property here
        }
    
        public void WriteXml(XmlWriter writer) {
            // Write out TimeStamp.ToString(
            //    System.Globalization.CultureInfo.InvariantCulture, 
            //    "proper format");
        }
    }
