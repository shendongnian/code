    void RemoveCheckedNodes(TreeNodeCollection nodes)
    {
        List<TreeNode> checkedNodes = new List<TreeNode>();
        foreach (TreeNode node in nodes)
        {
            if (node.Checked)
            {
                checkedNodes.Add(node);
            }
            else
            {
                RemoveCheckedNodes(nodes.ChildNodes);
            }
        }
        foreach (TreeNode checkedNode in checkedNodes)
        {
            nodes.Remove(checkedNode);
        }
    }
