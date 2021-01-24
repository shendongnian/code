    public TreeNode GetLastVisibleNode ()
    {
        var node = treeControl1.Nodes.Cast <TreeNode> ().Select (GetFirstVisibleNode).
                                FirstOrDefault (first => first != null);
        var retVal = node;
        while (node != null && node.IsVisible)
        {
            if (!node.IsSelected)
                retVal = node;
            node = node.NextVisibleNode;
        }
        return retVal;
        TreeNode GetFirstVisibleNode (TreeNode parentNode) =>
            parentNode.IsVisible
                ? parentNode
                : parentNode.Nodes.Cast <TreeNode> ().Select (GetFirstVisibleNode).
                             FirstOrDefault (childFirstNode => childFirstNode != null);
    }
