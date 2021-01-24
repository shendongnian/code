    void findPaths(int root, Dictionary<int,List<int>> tree,List<List<int>> pathList, List<int> visitedNodes)
	{
		visitedNodes.Add(root);
		if(tree.ContainsKey(root))
		{
			foreach(int v in tree[root])
			{
				findPaths(v,tree,pathList,visitedNodes);
				visitedNodes.RemoveAt(visitedNodes.Count - 1);
			}
		}
		else
		{
				pathList.Add(new List<int>(visitedNodes));
		}
	}
