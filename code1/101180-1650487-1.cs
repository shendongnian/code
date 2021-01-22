    public void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
    {
        TreeNode node = sender as TreeNode;
        if (node != null)
            MessageBox.Show(node.Text);
    }
