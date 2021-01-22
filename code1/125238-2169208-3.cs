    public void AddNode(Node n, TreeView tv)
    {
       TreeNode tn = tv.Nodes.Add(n.Value.Text);
       tn.Tag = n;
       foreach (Node child in n.Children)
       {
          AddNode(child, tn);
       }
    }
    public void AddNode(Node n, TreeNode parent)
    {
       TreeNode tn = parent.Nodes.Add(n.Value.Text);
       parent.Tag = n;
       foreach (Node child in n.Children)
       {
          AddNode(child, tn);
       }
    }
    
