    public TreeNode GetLastVisibleNode()
    {
        TreeNode node = treeControl1.TopNode;
        TreeNode retVal;
        do
        {
            retVal = node;
            node = node.NextVisibleNode;
        } while (node != null && node.IsVisible);
        return retVal;
    }
