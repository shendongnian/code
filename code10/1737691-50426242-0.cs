    public class CustomWriter : XmlTextWriter
    {
        private int counter = 1;
        public CustomWriter(TextWriter writer) : base(writer) { }
        public CustomWriter(Stream stream, Encoding encoding) : base(stream, encoding) { }
        public CustomWriter(string filename, Encoding encoding) : base(filename, encoding) { }
    
        public override void WriteStartElement(string prefix, string localName, string ns)
        {
            if (localName == "Info")
            {
                base.WriteStartElement(prefix, localName + counter.ToString("0##"), ns);
                counter++;
            }
            else
            {
                base.WriteStartElement(prefix, localName, ns);
            }
        }
    }
