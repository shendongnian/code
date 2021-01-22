    public static class XElementExtensions
    {
        public static XElement ElementByLocalName(this XElement element, string localName)
        {
            return element.Descendants().FirstOrDefault(e => e.Name.LocalName == localName && !e.IsEmpty);
        }
    }
