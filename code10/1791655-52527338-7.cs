    private static List<Project> Consolidate(List<Project> projects)
    {
        var result = new List<Project>();
        
        // if empty return
        if (!projects.Any()) return result;
        // adding first project to a new list
        // and removing it from the main list
        result.Add(projects.First());
        projects.Remove(projects.First());
        
        // loop over all projects in the main list
        projects.ForEach(p =>
        {
			var endDate = p.EndDate.HasValue ? p.EndDate.Value : DateTime.Today;
			
            // checking if any of the projects in the new list
            // starts within 24 hours of the end date of the
            // current project
            if (result.Any(r => r.BeginDate >= endDate && r.BeginDate.Subtract(endDate) <= TimeSpan.FromDays(1) && r.Name != p.Name))
            {
                // if you find any get it
                var match = result.First(r => r.BeginDate >= endDate && r.BeginDate.Subtract(endDate) <= TimeSpan.FromDays(1) && r.Name != p.Name);
                var index = result.IndexOf(match);
                // create new project that consalidate both projects
                result[index] = new Project(match.Name, p.BeginDate, match.EndDate);
            }
            else
            {
                // if didn't find any add the current 
                // project to the new list
                result.Add(p);
            }
        });
        return result;
    }
