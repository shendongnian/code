    public static class XPathValidator
    {
        /// <summary>
        /// Throws an XPathException if <paramref name="xpath"/> is not a valid XPath
        /// </summary>
        public static void Validate(string xpath)
        {
            using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes("<xml></xml>")))
            {
                XPathDocument doc = new XPathDocument(stream);
                XPathNavigator nav = doc.CreateNavigator();
                nav.Compile(xpath);
            }
        }
    }
