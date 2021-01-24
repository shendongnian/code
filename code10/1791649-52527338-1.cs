    private static List<Project> Consalidate(List<Project> projects)
    {
        var result = new List<Project>();
        if (!projects.Any()) return result;
        result.Add(projects.First());
        projects.Remove(projects.First());
        projects.ForEach(p =>
        {
            if (result.Any(r => r.BeginDate == (p.EndDate.HasValue ? p.EndDate.Value : DateTime.Today) && r.Name != p.Name))
            {
                var match = result.First(r => r.BeginDate == (p.EndDate.HasValue ? p.EndDate.Value : DateTime.Today));
                var index = result.IndexOf(match);
                result[index] = new Project(match.Name, p.BeginDate, match.EndDate);
            }
            else
            {
                result.Add(p);
            }
        });
        return result;
    }
