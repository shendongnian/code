    public struct SampleStruct : IXmlSerializable
    {
        private readonly int _data;
        public int Data { get { return _data; } }
        public SampleStruct(int data)
        {
             _data = data;
        }
        #region IXmlSerializableMembers
        public XmlSchema GetSchema() { return null; }
        public void ReadXml(XmlReader reader)
        {
            this = new SampleStruct(int.Parse(reader.ReadString()));
        }
        public void WriteXml(XmlWriter writer
        {
            writer.WriteString(data.ToString());
        }
        #endregion
    }
