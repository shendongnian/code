    private void TreeView_AfterCheck(object sender, TreeViewEventArgs e)
    {
        SetChildrenChecked(e.Node, e.Node.Checked);
    }
    
    private void SetChildrenChecked(TreeNode treeNode, bool checkedState)
    {
        foreach (TreeNode item in treeNode.Nodes)
        {
            item.Checked = checkedState;
        }
    }
