    [DataContract]
    public class SerializableDescription : IXmlSerializable
    {
        #region Properties
        public SerializableDescription()
        {
            
        }
        public SerializableDescription(Description description)
        {
            Description = description;
        }
        [DataMember]
        public Description Description { get; set; }
        #endregion
        #region Methods
        public XmlSchema GetSchema()
        {
            return null;
        }
        public void ReadXml(XmlReader reader)
        {
            reader.MoveToContent();
            string typeStr = reader.GetAttribute("Type");
            Type type = TypeCache.GetTypeEx(typeStr);
            XmlSerializer ser = new XmlSerializer(type);
            reader.ReadStartElement();
            Description = (Description)ser.Deserialize(reader);
            reader.ReadEndElement();
        }
        public void WriteXml(XmlWriter writer)
        {
            Type type = Description.GetType();
            writer.WriteAttributeString("Type", type.FullName);
            XmlSerializer ser = new XmlSerializer(type);
            ser.Serialize(writer, Description);
        }
        #endregion
    }
