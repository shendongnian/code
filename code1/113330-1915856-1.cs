    var nonUniqueFoo = list.SelectMany(a => a.Foo.Keys)
						.GroupBy( s => s)
						.Where( g => g.Count() > 1)
						.Select(g => g.Key);
						
						
    var nonUniqueBar = list.Select(a => a.Bar)
 						.GroupBy( i => i)
						.Where( g => g.Count() > 1)
						.Select(g => g.Key);
    var uniqueObject = list.Where( a=> !nonUniqueBar.Contains(a.Bar) )
                           .Where( a => !nonUniqueFoo.Intersect(a.Foo.Keys).Any() )
				  ;
