	var parents = children.Select( c => c.Parent ).Distinct();
	var grandParents = parents
		.Select( p => p.GrandParent )
		.Distinct()
		.ToDictionary
		( 
			g => g, 
			g => parents.Where( p => p.GrandParent == g )
		)
		.ToDictionary
		(
			pair => pair.Key,
			pair => pair.Value.SelectMany
			( 
				p => children.Where( c => c.Parent == p ) 
			)
		);
