    public static void MergeMissingContentFileNodes(string sourceFile, string destFile)
    {
        string topLevelNode = "content";
    	XmlDocument srcXml = new XmlDocument();
    	srcXml.Load(sourceFile);
    
    	XmlDocument destXml = new XmlDocument();
    	destXml.Load(destFile);
    
    	XmlNode srcContentNode = srcXml.SelectSingleNode(topLevelNode);
    	destXml = LoopThroughAndCreateMissingNodes(destXml, srcContentNode, topLevelNode);
        destXml.Save(destFile);
    	
    }
    
    public static XmlDocument LoopThroughAndCreateMissingNodes(XmlDocument destXml, XmlNode parentNode, string parentPath)
    {
    	foreach (XmlNode node in parentNode.ChildNodes) 
        {
    		//check if node exists and update destXML
    		if (node.NodeType == XmlNodeType.Element) 
            {
    			string currentPath = string.Format("{0}/{1}", parentPath, node.Name);
    			if (destXml.SelectSingleNode(currentPath) == null) 
                {
    				dynamic destParentNode = destXml.SelectSingleNode(parentPath);
    				destParentNode.AppendChild(destParentNode.OwnerDocument.ImportNode(node, true));
    			}
    			LoopThroughAndCreateMissingNodes(destXml, node, currentPath);
    			
    		}
    	}
    
    	return destXml;
    }
