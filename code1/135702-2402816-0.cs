    public class RecordExample : IXmlSerializable
    {
        public DateTime TheTime { get; set; }
        public DateTime TheDate { get; set; }
    
        public XmlSchema GetSchema()
        {
            return null;
        }
    
        public void ReadXml(XmlReader reader)
        {
            // TODO : Deserialization logic here
        }
    
        public void WriteXml(XmlWriter writer)
        {
            writer.WriteElementString(
                "date", 
                this.TheDate.ToString("yyyy-MM-dd"));
    
            writer.WriteElementString(
                "time", 
                this.TheTime.ToString("hh:mm:ss.fK"));
        }
    }
