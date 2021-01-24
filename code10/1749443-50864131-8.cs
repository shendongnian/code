	public static IEnumerable<FlatData> GetDescendents(this IEnumerable<FlatData> This, int rootId, int maxDepth)
	{
		var results = Enumerable.Range(0, maxDepth+1 ).Select( i => new List<FlatData>() ).ToList();
		results[0].Add
		(
			This.Single( x => x.Id == rootId ) 
		);
		for (int level = 1; level <= maxDepth; level++)
		{
			results[level].AddRange
			(
				results[level-1].SelectMany
				( 
					x => This.Where( y => y.ParentId == x.Id )
				)
			);
		}
		return results.SelectMany( x => x );
	}
