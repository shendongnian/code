    public class XmlTypeProxy : IXmlSerializable {
        private string _typeName;
        public XmlTypeProxy() {
        }
        public XmlTypeProxy(string typeName) {
            _typeName = typeName;
        }
        public XmlSchema GetSchema() {
            return null;
        }
        public void ReadXml(XmlReader reader) {
            _typeName = reader.ReadString();
        }
        public void WriteXml(XmlWriter writer) {
            writer.WriteString(_typeName);
        }
        public static implicit operator Type(XmlTypeProxy self) {
            return Type.GetType(self._typeName);
        }
        public static implicit operator XmlTypeProxy(Type self) {
            return new XmlTypeProxy(self.AssemblyQualifiedName);
        }
    }
