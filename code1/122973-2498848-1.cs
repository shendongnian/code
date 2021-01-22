    TreeNode curNode = e.Node;
    				curNode.FirstNode.Remove(); //Remove blank dummy node
    
    
    				ItemSet items = vcs.GetItems(curNode.Tag.ToString(), VersionSpec.Latest, RecursionType.OneLevel, DeletedState.Any, ItemType.Folder);
    
    				foreach (Item item in items.Items)
    				{
    					if (item.ServerItem == curNode.Tag.ToString()) //Ignore self
    						continue;
    
    					string Name = System.IO.Path.GetFileName(item.ServerItem);
    
    					TreeNode node = new TreeNode(Name, new TreeNode[] { new TreeNode() });
    					node.Tag = item.ServerItem;
    
    					if (item.DeletionId != 0)
    						node.ForeColor = Color.Red;
    
    					curNode.Nodes.Add(node);
    				}
