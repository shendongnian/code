    private void PopulateChildNodes(TreeNodeCollection parentCollection,
        IHierarchicalEnumerable children)
    {
        parentCollection.Clear();
        foreach (object child in children)
        {
            IHierarchyData childData = children.GetHierarchyData(child);
            TreeNode childNode = new TreeNode(childData.ToString());
            if (childData.HasChildren)
            {
                childNode.Nodes.Add("Dummy");   // Make expandable
            }
            nodeDictionary.Add(childNode, childData);
            parentCollection.Add(childNode);
        }
    }
    private void UpdateRootNodes(TreeView tv, IHierarchyData hierarchyData)
    {
        if (tv == null)
        {
            return;
        }
        tv.Nodes.Clear();
        if (hierarchyData != null)
        {
            IHierarchicalEnumerable roots = hierarchyData.GetChildren();
            PopulateChildNodes(tv.Nodes, roots);
        }
    }
