	private IEnumerable<TreeNode> LeafNodes(TreeNode root)
	{
		Stack<TreeNode> stack = new Stack<TreeNode>();
		stack.Push(root);
		while (stack.Count > 0)
		{
			TreeNode current = stack.Pop();
			if (current.Nodes.Count == 0)
			{
				yield return current;
			}
			else
			{
				foreach (TreeNode child in current.Nodes)
				{
					stack.Push(child);
				}
			}
		}
	}
