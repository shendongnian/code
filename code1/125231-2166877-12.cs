    private void PopulateTree(IEnumerable<MyObject> items)
    {
        var groupedItems =
            from i in items
            group i by i.Parent into g
            select new { Name = g.Key, Children = g.Select(c => c.Child) };
        var lookup = groupedItems.ToDictionary(i => i.Name, i => i.Children);
        foreach (string parent in lookup.Keys)
        {
            if (lookup.ContainsKey(parent))
                AddToTree(lookup, Enumerable.Empty<string>(), parent);
        }
    }
    private void AddToTree(Dictionary<string, IEnumerable<string>> lookup,
        IEnumerable<string> path, string name)
    {
        IEnumerable<string> children;
        if (lookup.TryGetValue(name, out children))
        {
            IEnumerable<string> newPath = path.Concat(new string[] { name });
            foreach (string child in children)
                AddToTree(lookup, newPath, child);
        }
        else
        {
            TreeNode parentNode = null;
            foreach (string item in path)
                parentNode = AddTreeNode(parentNode, item);
            AddTreeNode(parentNode, name);
        }
    }
    private TreeNode AddTreeNode(TreeNode parent, string name)
    {
        TreeNode node = new TreeNode(name);
        if (parent != null)
            parent.Nodes.Add(node);
        else
            treeView1.Nodes.Add(node);
        return node;
    }
