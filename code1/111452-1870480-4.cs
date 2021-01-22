    private void TreeView_AfterCheck(object sender, TreeViewEventArgs e)
    {
        SetChildrenChecked(e.Node, e.Node.Checked);
    
        if (e.Node.Parent != null)
        {
            bool setParentChecked = true;
            foreach (TreeNode node in e.Node.Parent.Nodes)
            {
                if (node.Checked != e.Node.Checked)
                {
                    setParentChecked = false;
                    break;
                }
            }
            if (setParentChecked)
            {
                e.Node.Parent.Checked = e.Node.Checked;
            }
        }
    }
    
    private void SetChildrenChecked(TreeNode treeNode, bool checkedState)
    {
        foreach (TreeNode item in treeNode.Nodes)
        {
            if (item.Checked != checkedState)
            {
                item.Checked = checkedState;
            }
        }
    }
