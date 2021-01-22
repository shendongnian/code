    public static class MyExtensions
    {
        public static XNode GetXNode(this XmlNode node)
        {
            return GetXElement(node);
        }
        public static XElement GetXElement(this XmlNode node)
        {
            XDocument xDoc = new XDocument();
            using (XmlWriter xmlWriter = xDoc.CreateWriter())
                node.WriteTo(xmlWriter);
            return xDoc.Root;
        }
        public static XmlNode GetXmlNode(this XElement element)
        {
            using (XmlReader xmlReader = element.CreateReader())
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(xmlReader);
                return xmlDoc;
            }
        }
        public static XmlNode GetXmlNode(this XNode node)
        {
            return GetXmlNode(node);
        }
    }
