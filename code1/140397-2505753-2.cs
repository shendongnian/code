    class MyXmlWriter : XmlTextWriter
    {
        public MyXmlWriter(TextWriter w)
            : base(w)
        {
        }
        public override void WriteStartElement(string prefix, string localName, string ns)
        {
            base.WriteStartElement("abc", localName, "urn-something");
        }
    }
