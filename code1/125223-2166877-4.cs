    public void PopulateTree(IEnumerable<MyObject> items)
    {
        var groupedItems =
            from i in items
            group i by i.Parent into g
            select new { Name = g.Key, Children = g };
        var lookup = groupedItems.ToDictionary(i => i.Name);
        foreach (string parent in lookup.Keys)
        {
            AddToTree(lookup, null, parent);
        }
    }    
    public void AddToTree(Dictionary<string, IEnumerable<MyObject>> lookup,
        TreeNode parent, string name)
    {
        TreeNode itemNode = new TreeNode(name);
        if (parent != null)
            parent.Nodes.Add(itemNode);
        else
            treeView.Nodes.Add(itemNode);
        foreach (MyObject childItem in lookup[name].Children)
        {
            AddToTree(itemNode, childItem.Child);
            AddToTree(null, childItem.Child);
        }
    }
