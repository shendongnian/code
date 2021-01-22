    public static class StringUtils
    {
        public string ToXmlElement(this string s, string elementName)
        {
           return string.Format("<{0}>{1}</{0}>", elementName, s);
        }
    }
            
