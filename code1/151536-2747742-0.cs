    private void treeView1_BeforeSelect(object sender, TreeViewCancelEventArgs e)
    {
       Dehighlight(treeView1.Nodes);
       e.Node.ForeColor = Color.Red;
       e.Cancel = true;
    }
    private void Dehighlight(TreeNodeCollection nodes)
    {
       foreach (TreeNode node in nodes)
       {
          node.BackColor = Color.White;
          node.ForeColor = Color.Black;
          Dehighlight(node.Nodes);
       }
    }
