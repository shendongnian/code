    public class Root
    {
        public string Name;
        [XmlIgnore]
        public string XmlString
        {
            get
            {
                if (SerializedXmlString == null)
                    return "";
                return SerializedXmlString.Value;
            }
            set
            {
                if (SerializedXmlString == null)
                    SerializedXmlString = new RawString();
                SerializedXmlString.Value = value;
            }
        }
        [XmlElement("XmlString")]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public RawString SerializedXmlString;
    }
    public class RawString : IXmlSerializable
    {
        public string Value { get; set; }
        public XmlSchema GetSchema()
        {
            return null;
        }
        public void ReadXml(System.Xml.XmlReader reader)
        {
            this.Value = reader.ReadInnerXml();
        }
        public void WriteXml(System.Xml.XmlWriter writer)
        {
            writer.WriteRaw(this.Value);
        }
    }
