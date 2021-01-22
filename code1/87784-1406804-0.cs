			using (Graphics g = Graphics.FromHwnd(Tree.Handle))
			{
				TreeNode node = myBlinkyNode;
				if (node != null)
				{
					using(Region myRegion = new Region(node.Bounds))
						myRegion.Xor(xorRect);
				}
			}
