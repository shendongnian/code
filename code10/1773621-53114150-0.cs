    public string GetPaths(int pathCounter, TreeNodeCollection nodes)
    {
        StringBuilder sb = new StringBuilder();
        foreach(TreeNode node in nodes)
        {
            if (node.Nodes.Count == 0)
                sb.Append($"{pathCounter++} {node.FullPath}\n");
            else
                sb.Append(GetPaths(pathCounter, node.Nodes));
        }
        return sb.ToString();
    }
