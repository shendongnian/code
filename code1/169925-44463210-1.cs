	class DependencyPrinter
	{
		private DependencyTree _dependencyTree;
		public DependencyPrinter(DependencyTree dependencyTree)
		{
			_dependencyTree = dependencyTree;
		}
		public void PrintDependency2(TreeView treeView)
		{
			var n = treeView.Nodes.Add("");
			AddToTreeNode(n, _dependencyTree.FirstChild);
		}
		private void AddToTreeNode(TreeNode treeNode, DependencyTreeNode node)
		{
			treeNode.Text = String.Format("({0}).{1}.{2}.{3}"
				, node.Urn.Type
				, node.Urn.XPathExpression.GetAttribute("Name", "Database")
				, node.Urn.XPathExpression.GetAttribute("Schema", node.Urn.Type)
				, node.Urn.XPathExpression.GetAttribute("Name", node.Urn.Type));
			if (node.FirstChild != null)
			{
				var n = treeNode.Nodes.Add("");
				AddToTreeNode(n, node.FirstChild);
			}
			if (node.NextSibling != null)
			{
				var n = treeNode.Parent.Nodes.Add("");
				AddToTreeNode(n, node.NextSibling);
			}
		}
	}
