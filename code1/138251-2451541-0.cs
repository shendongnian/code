    public static class ExtensionMethods
    {
        public string GetNodeText(this XmlNode node, string xPath)
        {
            var childNode = node.SelectSingleNode(xPath);
            return (childNode == null)
                ? "" : childNode.InnerText;
        }
    }
    searchResults.SearchResultCollection.Add(
        new SearchResult()
            {
                Header = HttpUtility.HtmlDecode(
                        htmlDocument.DocumentNode.GetNodeText(initialXPath + "h3"),
                Link = HttpUtility.HtmlDecode(
                        htmlDocument.DocumentNode.GetNodeText(initialXPath + "div/cite")
            }
        );
