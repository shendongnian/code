    public static TreeNode BuildTree(List<TreeNode> nodes)
    {
        foreach (var node in nodes)
        {
            node.Children = nodes.Where(x => x.ParentID == node.Id).ToList();
        }
        return nodes.Find(x => x.IsRoot);
    }
