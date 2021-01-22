    public class NamespaceSupressingXmlWriter : XmlWriterWrapper
    {
        //Provide as many contructors as you need
        public NamespaceSupressingXmlWriter(System.IO.TextWriter output)
            : base(XmlWriter.Create(output)) { }
        public NamespaceSupressingXmlWriter(XmlWriter output)
            : base(XmlWriter.Create(output)) { }
        public override void WriteStartElement(string prefix, string localName, string ns)
        {
            base.WriteStartElement("", localName, "");
        }
    }
