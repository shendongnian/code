    public void PopulateTreeView(IEnumerable<MyObject> objects, TreeView t)
    {
       foreach (MyObject o in objects)
       {
          Node n = Node.Create(o);
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
