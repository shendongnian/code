    private static List<HtmlNode> GetMatchingNodes(string xPath, string pattern, HtmlDocument htmlDocument)
    {
    	List<HtmlNode> matchingNodes = new List<HtmlNode>();
    	foreach (HtmlNode node in htmlDocument.DocumentNode.SelectNodes(xPath))
    	{
    		if (Regex.IsMatch(node.InnerHtml, pattern))
    		{
    			matchingNodes.Add(node);
    		}
    	}
    	return matchingNodes;
    }
