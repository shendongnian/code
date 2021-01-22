    public static List<Node> SelectChildrenByNameRecursive(Node node, string docType)
    {
        var nodes = new List<Node>();
    
        foreach (Node child in node.Children)
        {
            FindChildrenByDocType(child, docType, ref nodes);
        }
    
        return nodes;
    }
    
    private static void FindChildrenByDocType(Node node, string docType, ref List<Node> nodes)
    {
        if (node.NodeTypeAlias == docType)
        {
            nodes.Add(node);
        }
        foreach (Node childNode in node.Children)
        {
            FindChildrenByDocType(childNode, docType, ref nodes);
        }
    }
