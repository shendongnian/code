    public static class XHtml
    {
        static XHtml()
        {
            Namespace = "http://www.w3.org/1999/xhtml";
        }
        
        public static XNamespace Namespace { get; private set; }
        
        public static XElement Element(string name)
        {
            return new XElement(Namespace + name);
        }
        
        public static XElement Element(string name, params object[] content)
        {
            return new XElement(Namespace + name, content);
        }
        
        public static XElement Element(string name, object content)
        {
            return new XElement(Namespace + name, content);
        }
        
        public static XAttribute Attribute(string name, object value)
        {
            return new XAttribute(/* Namespace + */ name, value);
        }
        
        public static XText Text(string text)
        {
            return new XText(text);
        }
        
        public static XElement A(string url, params object[] content)
        {
            XElement result = Element("a", content);
            result.Add(Attribute("href", url));
            return result;
        }
    }
