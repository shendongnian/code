    private void addParentNode_Click(object sender, EventArgs e) {
      treeView2.BeginUpdate();
      treeView2.Nodes.Clear();
      string yourParentNode;
      yourParentNode = textBox1.Text.Trim();
      treeView2.Nodes.Add(yourParentNode);
      treeView2.EndUpdate();
    }
    private void addChildNode_Click(object sender, EventArgs e) {
      string yourChildNode;
      yourChildNode = textBox1.Text.Trim();
      treeView2.Nodes[0].Nodes.Add(yourChildNode);
      treeView2.ExpandAll();
    }
