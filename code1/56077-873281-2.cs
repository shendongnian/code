    // helper class to ignore namespaces when de-serializing
    public class NamespaceIgnorantXmlTextReader : XmlTextReader
    {
        public NamespaceIgnorantXmlTextReader(System.IO.TextReader reader): base(reader) { }
        public override string NamespaceURI
        {
            get { return ""; }
        }
    }
    // helper class to omit XML decl at start of document when serializing
    public class XTWFND  : XmlTextWriter {
        public XTWFND (System.IO.TextWriter w) : base(w) { Formatting= System.Xml.Formatting.Indented;}
        public override void WriteStartDocument () { }
    }
