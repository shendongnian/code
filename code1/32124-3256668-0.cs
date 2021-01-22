        public static void Main(string[] args)
        {
            XmlDocument doc = new XmlDocument();
            XmlNode rootNode = GenerateXPathXmlElements(doc, "/RootNode/FirstChild/SecondChild/ThirdChild");
            Console.Write(rootNode.OuterXml);
        }
        private static XmlDocument GenerateXPathXmlElements(XmlDocument xmlDocument, string xpath)
        {
            XmlNode parentNode = xmlDocument;
            if (xmlDocument != null && !string.IsNullOrEmpty(xpath))
            {
                string[] partsOfXPath = xpath.Split('/');
                               
                               
                string xPathSoFar = string.Empty;
                
                foreach (string xPathElement in partsOfXPath)
                {
                    if(string.IsNullOrEmpty(xPathElement))
                        continue;
                    xPathSoFar += "/" + xPathElement.Trim();
                    XmlNode childNode = xmlDocument.SelectSingleNode(xPathSoFar);
                    if(childNode == null)
                    {
                        childNode = xmlDocument.CreateElement(xPathElement);
                    }
                    parentNode.AppendChild(childNode);
                    parentNode = childNode;
                }
            }
            return xmlDocument;
        }
