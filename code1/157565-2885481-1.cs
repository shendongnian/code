    private void checkAllParents(TreeNode node)
    {
      var parent = node.Parent;
      var visitedNodes = new List<TreeNode>();
      while (parent != null)
      {
        if (visitedNodes.Contains(parent))
          throw new InvalidOperationException("Circular reference!");
        visitedNodes.Add(parent);
        parent.Checked = true;
        parent = parent.Parent;
      }
    }
