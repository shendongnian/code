    XmlNode node;
    searchResults.SearchResultCollection.Add(
        new SearchResult
        {
            Header = HttpUtility.HtmlDecode(
                htmlDocument.DocumentNode
                    .TrySelectSingleNode(initialXPath + "h3", out node)
                        ? node.InnerText
                        : null),
            Link = HttpUtility.HtmlDecode(
                htmlDocument.DocumentNode
                    .TrySelectSingleNode(initialXPath + "div/cite", out node)
                        ? node.InnerText
                        : null)
        });
