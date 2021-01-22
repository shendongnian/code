        public class Test : IXmlSerializable
        {
            private List<TestEvent> _Events = new List<TestEvent>();
            public List<TestEvent> Events { get { return _Events; } }
            #region IXmlSerializable Members
            public System.Xml.Schema.XmlSchema GetSchema()
            {
                return null;
            }
            public void ReadXml(System.Xml.XmlReader reader)
            {
                throw new NotImplementedException();
            }
            public void WriteXml(System.Xml.XmlWriter writer)
            {
                writer.WriteStartElement("events");
                foreach (var item in Events)
                {
                    writer.WriteElementString(item.Type.ToString().ToLower(), "");
                }
                writer.WriteEndElement();
            }
            #endregion
        }
