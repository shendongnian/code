    public static TreeNode ToTreeNode(Node root)
	{
		var treeNode = new TreeNode(root.Name);
		foreach (var node in root.Children)
		{
			treeNode.Nodes.Add(ToTreeNode(node));
		}
		return treeNode;
	}
