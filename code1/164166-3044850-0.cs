    public string GetNodeValue(XmlNodeList list, string name)
    {
        foreach (XmlNode node in list)
        {
            if (!node.HasChildNodes)
            {
                if (node.ParentNode.Name == name)
                {
                    return arg_node.Value;
                }
            }
            else
            {
                // Only return if we've found something within this node's child list
                string childValue = GetNodeValue(node.ChildNodes, name);
                if (childValue != "")
                {
                    return childValue;
                }
            }
        }
        return "";
    }
