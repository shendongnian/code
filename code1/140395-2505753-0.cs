    class MyXmlReader : XmlTextReader
    {
        public MyXmlReader(TextReader r) : base(r)
        {
        }
        public override string Prefix
        {
            get
            {
                return "abc";
            }
        }
        public override string NamespaceURI
        {
            get
            {
                return "urn:something";
            }
        }
    }
