    class SimpleNameTable : XmlNameTable {
        List<string> cache = new List<string>();
        public override string Add(string array) {
            string found = cache.Find(s => s == array);
            if (found != null) return found;
            cache.Add(array);
            return array;
        }
        public override string Add(char[] array, int offset, int length) {
            return Add(new string(array, offset, length));
        }
        public override string Get(string array) {
            return cache.Find(s => s == array);
        }
        public override string Get(char[] array, int offset, int length) {
            return Get(new string(array, offset, length));
        }
    }
    static void Main() {
        XmlNamespaceManager mgr = new XmlNamespaceManager(new SimpleNameTable());
        mgr.AddNamespace("a", "http://foo/bar");
        XmlParserContext ctx = new XmlParserContext(null, mgr, null,
            XmlSpace.Default);
        using (XmlReader reader = XmlReader.Create(
            new StringReader(@"<root><a:element/></root>"), null, ctx)) {
            XDocument doc = XDocument.Load(reader);
            //XmlDocument doc = new XmlDocument();
            //doc.Load(reader);
        }
    }
