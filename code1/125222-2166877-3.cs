    public void PopulateTree(IEnumerable<MyObject> items)
    {
        foreach (MyObject item in items)
        {
            AddToTree(null, item);
        }
    }
    public void AddToTree(TreeNode parent, MyObject item)
    {
        TreeNode itemNode = new TreeNode(item.Text);
        if (parent != null)
            parent.Nodes.Add(itemNode);
        else
            treeView.Nodes.Add(itemNode);
        foreach (MyObject childItem in item.Children)
        {
            AddToTree(itemNode, childItem);
            AddToTree(null, childItem);
        }
    }
