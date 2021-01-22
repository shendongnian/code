	result = session.CreateCriteria<Vehicle>()
		.CreateAlias( "Applications", "a" )
		.Add( Expression.Eq( "Make ", make ) )
		.Add( Expression.Eq( "a.Name", applicationname ) )
		.List<Vehicle>();
