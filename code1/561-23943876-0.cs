    private void treeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
    {
        if (e.Button == System.Windows.Forms.MouseButtons.Right)
            e.Node.TreeView.SelectedNode = e.Node;
    }
