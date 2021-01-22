    using System.Xml;
    using System.Xml.Schema;
    using System.Xml.Serialization;
    
    namespace AMain.CommonScaffold
    {
        public struct SafeBool : IXmlSerializable
        {
            private bool _value;
    
            /// <summary>
            /// Allow implicit cast to a real bool
            /// </summary>
            /// <param name="yn">Value to cast to bool</param>
            public static implicit operator bool(
                SafeBool yn)
            {
                return yn._value;
            }
    
            /// <summary>
            /// Allow implicit cast from a real bool
            /// </summary>
            /// <param name="b">Value to cash to y/n</param>
            public static implicit operator SafeBool(
                bool b)
            {
                return new SafeBool { _value = b };
            }
    
            /// <summary>
            /// This is not used
            /// </summary>
            public XmlSchema GetSchema()
            {
                return null;
            }
    
            /// <summary>
            /// Reads a value from XML
            /// </summary>
            /// <param name="reader">XML reader to read</param>
            public void ReadXml(
                XmlReader reader)
            {
                var s = reader.ReadElementContentAsString().ToLowerInvariant();
                _value = s == "true" || s == "yes" || s == "y";
            }
    
            /// <summary>
            /// Writes the value to XML
            /// </summary>
            /// <param name="writer">XML writer to write to</param>
            public void WriteXml(
                XmlWriter writer)
            {
                writer.WriteString(_value ? "true" : "false");
            }
        }
    }
