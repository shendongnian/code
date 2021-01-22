			treeView.Sort(); //Alphabetically ordered
			//Get Initial List of Projects
			try
			{
				ItemSet itemSet = vcs.GetItems(@"$/", RecursionType.OneLevel);
				foreach (Item item in itemSet.Items)
				{
					if (item.ServerItem == @"$/") //Ignore self
						continue;
					TreeNode node = new TreeNode(item.ServerItem, new TreeNode[] { new TreeNode() });
					node.Tag = item.ServerItem;
					if (item.DeletionId != 0)
						node.ForeColor = Color.Red;
					treeView.Nodes.Add(node);
				}
			}
