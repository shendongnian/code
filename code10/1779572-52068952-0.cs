    static XmlNode SearchNode(XmlNodeList nodeList, string nodeName)
    {
    	for (int i = 0; i < nodeList.Count; i++)
    	{
    		if (nodeList[i].Name == nodeName)
    		{
    			return nodeList[i];
    		}
    
    		if (nodeList[i].HasChildNodes)
    		{
    			XmlNode node = SearchNode(nodeList[i].ChildNodes, nodeName);
    			if (node != null)
    			{
    				return node;
    			}
    		}
    	}
    
    	return null;
    }
   
    static XmlNodeList SearchNodeByPath(XmlNodeList nodeList, string xPath)
    {
    	for (int i = 0; i < nodeList.Count; i++)
    	{
    		var nodes = nodeList[i].SelectNodes(xPath);
    		if (nodes != null && nodes.Count > 0)
    		{
    			return nodes;
    		}
    
    		if (nodeList[i].HasChildNodes)
    		{
    			XmlNodeList innerNodes = SearchNodeByPath(nodeList[i].ChildNodes, xPath);
    			if (innerNodes != null && innerNodes.Count > 0)
    			{
    				return innerNodes;
    			}
    		}
    	}
    
    	return null;
    }
