    public class SerializableStringDictionary : StringDictionary, IXmlSerializable
    {
        public XmlSchema GetSchema()
        {
            return null;
        }
        public void ReadXml(XmlReader reader)
        {
            while (reader.Read() &&
                !(reader.NodeType == XmlNodeType.EndElement && reader.LocalName == this.GetType().Name))
            {
                var name = reader["Name"];
                if (name == null)
                    throw new FormatException();
                var value = reader["Value"];
                this[name] = value;
            }
        }
        public void WriteXml(XmlWriter writer)
        {
            foreach (var key in Keys)
            {
                writer.WriteStartElement("Pair");
                writer.WriteAttributeString("Name", (string) key);
                writer.WriteAttributeString("Value", this[(string) key]);
                writer.WriteEndElement();
            }
        }
    }
