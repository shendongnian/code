    // use this instead of a bool, and it will serialize to "yes" or "no"
    // minimal example, not very robust
    public struct YesNo : IXmlSerializable {
        // we're just wrapping a bool
        private bool Value;
        // allow implicit casts to/from bool
        public static implicit operator bool(YesNo yn) {
            return yn.Value;
        }
        public static implicit operator YesNo(bool b) {
            return new YesNo() {Value = b};
        }
        // implement IXmlSerializable
        public XmlSchema GetSchema() { return null; }
        public void ReadXml(XmlReader reader) {
            Value = (reader.ReadElementContentAsString() == "yes");
        }
        public void WriteXml(XmlWriter writer) {
            writer.WriteString((Value) ? "yes" : "no");
        }
    }
