	vehicles = session.CreateCriteria<Vehicle>()
		.Add( Expression.Eq( "Make ", make ) )
		.List<Vehicle>();
	dto = vehicles
            .Select(v => new DTO
            {
                 IsLinked = v.Applications.Any(a => a.Name == applicationname )
            })
            .ToList();
