    private void addChildNode_Click(object sender, EventArgs e) {
      var childNode = textBox1.Text.Trim();
      if (!string.IsNullOrEmpty(childNode)) {
        TreeNode parentNode = treeView2.SelectedNode ?? treeView2.Nodes[0];
        if (parentNode != null) {
          parentNode.Nodes.Add(childNode);
          treeView2.ExpandAll();
        }
      }
    }
