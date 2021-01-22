        /// <summary>
        /// Extracts an HtmlDocument DOM to an XElement DOM that can be queried using LINQ to XML.
        /// </summary>
        /// <param name="htmlDocument">HtmlDocument containing DOM of page to extract.</param>
        /// <returns>HTML content as <see cref="XElement" /> for consumption by LINQ to XML.</returns>
        public XElement ExtractXml(HtmlDocument htmlDocument) {
            XmlDocument xmlDoc = htmlDocument.ToXMLDocument();
            // Find and remove all script tags from XML DOM or LINQ to XML will choke on XElement.Parse(XmlDocument).
            IList<XmlNode> nodes = new List<XmlNode>();
            foreach (XmlNode node in xmlDoc.GetElementsByTagName("script"))
                nodes.Add(node);
            foreach (XmlNode node in nodes)
                node.ParentNode.RemoveChild(node);
            return XElement.Parse(xmlDoc.OuterXml);
        }
