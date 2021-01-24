			int count = xtlItemList.Nodes.Count;
			List<TreeListNode> nodes = new List<TreeListNode>();
			nodes.AddRange(xtlItemList.Nodes); // save the nodes with their position
			xtlItemList.BeginSort();
			xtlItemList.Columns[2].SortOrder = SortOrder.None;
			xtlItemList.EndSort();
			for (int i = 0; i < nodes.Count; i++)
			{
				xtlItemList.SetNodeIndex(nodes[i], i); // set nodes to the original position
			}
