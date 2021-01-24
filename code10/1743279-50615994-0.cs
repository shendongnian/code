    private void FluidFilterTree_AfterCheck(object sender, TreeViewEventArgs e)
    {
        var activeNode = e.Node;
        if (activeNode.Parent == null)
            foreach (TreeNode child in activeNode.Nodes)
                child.Checked = false;
        MessageBox.Show(e.Node.Text);
    }
