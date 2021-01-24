	public IQueryable<ProjectModel> GetProjectQuery(ProjectTrackingDBEntities context) {
		return context.TimeEntries.Where(Entry => Entry.Date >= FilterProjectAfterDate
									&& Entry.Date <= FilterProjectBeforerDate
									&& (FilterProjectName != null ? Entry.ProjectName.Contains(FilterProjectName) : true))
			.GroupBy(m => new { m.ProjectName, m.Phase })
			.Join(context.Projects, m => new { m.Key.ProjectName, m.Key.Phase }, w => new { w.ProjectName, w.Phase }, (m, w) => new { te = m, proj = w })
			.Select(m => new ProjectModel
			{
				Name = m.te.Key.ProjectName,
				Phase = m.te.Key.Phase,
				TimeWorked = m.te.Sum(w => w.TimeWorked),
				ProposedCompletionDate = m.proj.ProposedCompletionDate,
				ActualCompletionDate = m.proj.ActualCompletionDate,
				Active = m.proj.Active,
				StartDate = m.proj.StartDate,
				Description = m.proj.Description,
				EstimatedHours = m.proj.EstimatedHours
			});
	}
	
