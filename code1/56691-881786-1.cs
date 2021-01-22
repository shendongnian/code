    private void addChildNode_Click(object sender, EventArgs e) {
      TreeNode ParentNode = treeView2.SelectedNode;  // for ease of debugging!
      if (ParentNode != null) {
        ParentNode.Nodes.Add("Name Of Node");
        treeView2.ExpandAll();   // so you can see what's been added              
        treeView2.Invalidate();  // requests a redraw
      }
    }
