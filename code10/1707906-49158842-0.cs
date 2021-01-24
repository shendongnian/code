    public IEnumerable<TimeEntries> GetTimeEntries()
    {
        using (ProjectTrackingDBEntities context = new ProjectTrackingDBEntities())
        {
            return context.TimeEntries
			    .Where
				(
				    Entry => 
					Entry.Date >= FilterProjectAfterDate &&
					Entry.Date <= FilterProjectBeforerDate &&
                    (FilterProjectName != null ? Entry.ProjectName.Contains(FilterProjectName) : true)
				)
				.GroupBy(m => new { m.ProjectName, m.Phase })
				.Join
				(
				    context.Projects, 
					m => new { m.Key.ProjectName, m.Key.Phase }, 
					w => new { w.ProjectName, w.Phase }, 
					(m, w) => new { te = m, proj = w }
				);
	    }
	)
