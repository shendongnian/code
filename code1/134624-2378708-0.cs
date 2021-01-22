    public List<Node> MakeTreeFromFlatList(IEnumerable<Node> flatList)
    {
        var dic = flatList.ToDictionary(n => n.Id, n => n);
        var rootNodes = new List<Node>();
        foreach(var node in flatList)
        {
            if (node.ParentId.HasValue)
            {
                Node parent = dic[node.ParentId.Value];
                node.Parent = parent;
                parent.Children.Add(node);
            }
            else
            {
                rootNodes.Add(node);
            }
        }
        return rootNodes;
    }
