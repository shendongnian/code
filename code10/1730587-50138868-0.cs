	public int CountTreeNodes(TreeNodeCollection nodes)
	{
		int count = nodes.Count;
		foreach (TreeNode node in nodes)
		{
			if (node.Nodes.Count > 0) count += CountTreeNodes(node.Nodes);
		}
		return count;
	}
