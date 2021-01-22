    namespace My.XmlSerialization
    {
        public struct TimeSpan : IXmlSerializable
        {
            private System.TimeSpan _value;
            public static implicit operator TimeSpan(System.TimeSpan value)
            {
                return new TimeSpan { _value = value };
            }
            public static implicit operator System.TimeSpan(TimeSpan value)
            {
                return value._value;
            }
            public XmlSchema GetSchema()
            {
                return null;
            }
            public void ReadXml(XmlReader reader)
            {
                _value = System.TimeSpan.Parse(reader.ReadContentAsString());
            }
            public void WriteXml(XmlWriter writer)
            {
                writer.WriteValue(_value.ToString());
            }
        }
    }
