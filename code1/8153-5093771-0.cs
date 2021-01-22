    internal class XElementFactory
    {
        private readonly XNamespace currentNs;
        public XElementFactory(XNamespace ns)
        {
            this.currentNs = ns;
        }
        internal XElement CreateXElement(String name, params object[] content)
        {
            return new XElement(currentNs + name, content);
        }
    }
