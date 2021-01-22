    public void PopulateTreeView(IEnumerable<string> parents, TreeView t)
    {
       foreach (string parentKey in parents)
       {
          Node n = Node.Create(parentKey);
          AddNode(n, t);
          foreach (Node descendant in n.Descendants)
          {
             if (n.HasChildren)
             {
                AddNode(descendant, t);
             }
          }
       }
    }
