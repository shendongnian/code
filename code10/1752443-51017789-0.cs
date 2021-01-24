    public class XmlReaderNoNamespaces : XmlTextReader
    {
        public XmlReaderNoNamespaces(Stream stream) : base(stream)
        {
        }
        public override string Name => LocalName;
        public override string NamespaceURI => string.Empty;
        public override string Prefix => string.Empty;
    }
