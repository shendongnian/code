    public static void BuildTreeView(TreeNodeCollection Parent, List<TermNode> TermNodeList)
    {
      foreach (TermNode n in TermNodeList)
      {
        TreeNode CurrentNode = Parent.Add(n.Name);
        // no need to recurse on empty list
        if (n.List.Count > 0) BuildTreeView(CurrentNode.Nodes, n.List);
      }
    }
    // initial call
    List<TermNode> AllTermNodes = /* all your nodes at root level */;
    
    BuildTreeView(treeView1.Nodes, AllTermNodes);
