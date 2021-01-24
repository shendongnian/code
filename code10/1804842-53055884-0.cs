    public class MySTADMessage : IXmlSerializable
    {
        public string Message { get; set; }
        public XmlSchema GetSchema()
        {
            return null;
        }
        public void ReadXml(XmlReader reader)
        {
            // IsNullable = true is ignored, apparently.  You won't get an actual
            // null for properties deserialized this way because the serializer
            // already created an instance of this class.
            if (reader.GetAttribute("nil", XmlSchema.InstanceNamespace) == "true")
                return;
            reader.ReadStartElement();
            while (reader.NodeType == XmlNodeType.Whitespace)
                reader.Read();
            if (reader.NodeType == XmlNodeType.Text)
            {
                Message = reader.ReadContentAsString();
            }
            else if (reader.NodeType == XmlNodeType.Element)
            {
                if (reader.Name != "Message")
                    throw new Exception("Unexpected element name.");
                reader.ReadStartElement();
                if (reader.NodeType == XmlNodeType.Text)
                {
                    Message = reader.ReadContentAsString();
                }
                else
                {
                    throw new Exception("Unexpected node type.");
                }
                reader.ReadEndElement();
            }
            else
            {
                throw new Exception("Unexpected node type.");
            }
            reader.ReadEndElement();
        }
        public void WriteXml(XmlWriter writer)
        {
            // Not having the extra Message element is simpler.
            writer.WriteString(Message);
        }
    }
