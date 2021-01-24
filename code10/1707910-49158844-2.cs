	using (ProjectTrackingDBEntities context = new ProjectTrackingDBEntities())
	{	
		var ReturnedQuery = GetProjectsQuery(context);
		foreach(var item in ReturnedQuery)
		{
			//do stuff
		}
	}
