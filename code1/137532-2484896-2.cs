    private void RegisterEvents(TreeView tv)
    {
        tv.BeforeExpand += TreeViewBeforeExpand;
    }
    private void UnregisterEvents(TreeView tv)
    {
        tv.BeforeExpand -= TreeViewBeforeExpand;
    }
    private void TreeViewBeforeExpand(object sender, TreeViewCancelEventArgs e)
    {
        if (e.Node.Checked)
        {
            return;
        }
        IHierarchyData hierarchyData;
        if (nodeDictionary.TryGetValue(e.Node, out hierarchyData))
        {
            PopulateChildNodes(e.Node.Nodes, hierarchyData.GetChildren());
            e.Node.Checked = true;
        }
    }
