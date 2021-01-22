    public class NoNamespaceXmlWriter : XmlTextWriter
    {
        //Provide as many contructors as you need
        public NoNamespaceXmlWriter(System.IO.TextWriter output)
            : base(output) { Formatting= System.Xml.Formatting.Indented;}
        
        public override void WriteStartDocument () { }
        public override void WriteStartElement(string prefix, string localName, string ns)
        {
            base.WriteStartElement("", localName, "");
        }
    }
