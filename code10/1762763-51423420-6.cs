    TreeNode GetFirstVisibleNode (TreeNode parentNode)
    {
        if (parentNode.IsVisible)
            return parentNode;
        foreach (var childNode in parentNode.Nodes.Cast <TreeNode> ())
        {
            var childFirstNode = GetFirstVisibleNode (childNode);
            if (childFirstNode != null)
                return childFirstNode;
        }
        return null;
    }
