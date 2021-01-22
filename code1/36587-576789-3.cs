    [Serializable]
    public class Foo : IXmlSerializable
    {
        public Foo() { }
        public Foo(string abc, byte[] bcd)
        {
            Abc = abc;
            Bcd = bcd;
        }
        public string Abc { get; private set; }
        public byte[] Bcd { get; private set; }
        
        XmlSchema IXmlSerializable.GetSchema()
        {
            return null;
        }
    
        void IXmlSerializable.WriteXml(System.Xml.XmlWriter writer)
        {
            if (Abc != null)
            {
                writer.WriteElementString("Abc", Abc);
            }
            if (Bcd != null)
            {
                writer.WriteStartElement("Bcd");
                writer.WriteBase64(Bcd, 0, Bcd.Length);
                writer.WriteEndElement();
            }
        }
        void IXmlSerializable.ReadXml(System.Xml.XmlReader reader)
        {
            reader.ReadStartElement();
            reader.ReadStartElement("Abc");
            Abc = reader.ReadString();
            reader.ReadEndElement();
            reader.ReadStartElement("Bcd");
            reader.Read();
            MemoryStream ms = null;
            byte[] buffer = new byte[256];
            int bytesRead;
            while ((bytesRead = reader.ReadContentAsBase64(buffer, 0, buffer.Length)) > 0)
            {
                if (ms == null) ms = new MemoryStream(bytesRead);
                ms.Write(buffer, 0, bytesRead);
            }
            if (ms != null) Bcd = ms.ToArray();
            reader.ReadEndElement();        
        }
    }
