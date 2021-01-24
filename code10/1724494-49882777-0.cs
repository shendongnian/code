	public IEnumerable<TreeNode> GetVisibleNodes(TreeView view)
	{
		List<TreeNode> nodes = new List<TreeNode>();
		foreach (TreeNode node in view.Nodes)
		{                
			nodes.AddRange(TraverseNode(node));
		}
		return nodes;
	}
	private IEnumerable<TreeNode> TraverseNode(TreeNode node)
	{
		List<TreeNode> visibleNodes = new List<TreeNode>();
		visibleNodes.Add(node);
		if (node.IsExpanded)
		{
			foreach (TreeNode childNode in node.Nodes)
			{
				visibleNodes.AddRange(TraverseNode(childNode));
			}
		}
		return visibleNodes;
	}
