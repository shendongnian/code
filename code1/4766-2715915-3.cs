    public class NetService : IXmlSerializable
    {
        #region Data
            public string Identifier = String.Empty;
            public string Name = String.Empty;
            public IPAddress Address = IPAddress.None;
            public int Port = 7777;
        #endregion
        #region IXmlSerializable Implementation
            public XmlSchema GetSchema() { return (null); }
            public void ReadXml(XmlReader reader)
            {
                // Attributes
                Identifier = reader[XML_IDENTIFIER];
                if (Int32.TryParse(reader[XML_NETWORK_PORT], out Port) == false)
                throw new XmlException("unable to parse the element " + typeof(NetService).Name + " (badly formatted parameter " + XML_NETWORK_PORT);
                if (IPAddress.TryParse(reader[XML_NETWORK_ADDR], out Address) == false)
                throw new XmlException("unable to parse the element " + typeof(NetService).Name + " (badly formatted parameter " + XML_NETWORK_ADDR);
            }
            public void WriteXml(XmlWriter writer)
            {
                // Attributes
                writer.WriteAttributeString(XML_IDENTIFIER, Identifier);
                writer.WriteAttributeString(XML_NETWORK_ADDR, Address.ToString());
                writer.WriteAttributeString(XML_NETWORK_PORT, Port.ToString());
            }
            private const string XML_IDENTIFIER = "Id";
            private const string XML_NETWORK_ADDR = "Address";
            private const string XML_NETWORK_PORT = "Port";
        #endregion
    }
