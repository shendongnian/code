    public static class XmlExtensions
    {
        public static XmlElement WithText(this XmlElement element, string text)
        {
            element.InnerText = text;
            return element;
        }
    }
