    //This is basic - you may need to modify logically to fit your needs
    void ManageTreeChecked(TreeNode node)
    {
       foreach(TreeNode n in node.Nodes)
       {
          n.Checked = node.Checked;
       }
    }
    private void convTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
    {
       ManageTreeChecked(e.Node);
    }
    private void convTreeView_KeyUp(object sender, KeyEventArgs e)
    {
       if (e.KeyCode == Keys.Space)
       {
          ManageTreeChecked(convTreeView.SelectedNode);
       }
    }
