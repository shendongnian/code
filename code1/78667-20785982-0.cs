    private void treeView_blockInfo_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
    {
        if (!e.Node.IsExpanded)
        {
            e.Node.Expand();
        }
        else
        {
            e.Node.Collapse();
        }
    }
