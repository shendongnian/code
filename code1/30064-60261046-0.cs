    /// <summary>
    /// Rename Node
    /// </summary>
    /// <param name="parentnode"></param>
    /// <param name="oldname"></param>
    /// <param name="newname"></param>
    private static void RenameNode(XmlNode parentnode, string oldChildName, string newChildName)
    {
    	var newnode = parentnode.OwnerDocument.CreateNode(XmlNodeType.Element, newChildName, "");
    	var oldNode = parentnode.SelectSingleNode(oldChildName);
    
    	foreach (XmlAttribute att in oldNode.Attributes)
    		newnode.Attributes.Append(att);
    	foreach (XmlNode child in oldNode.ChildNodes)
    		newnode.AppendChild(child);
    
    	parentnode.ReplaceChild(newnode, oldNode);
    }
