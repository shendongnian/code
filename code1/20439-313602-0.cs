    public static void BuildTreeView(TreeNode Parent, List<TermNode> TermNodeList)
    {
      foreach (TermNode n in TermNodeList)
      {
        TreeNode CurrentNode = Parent.Nodes.Add(n.Name);
        // no need to recurse on empty list
        if (n.List.Count > 0) BuildTreeView(CurrentNode, n.List);
      }
    }
    // initial call
    List<TermNode> AllTermNodes = /* all your nodes at root level */;
    
    BuildTreeView(treeView1.Nodes, AllTermNodes);
