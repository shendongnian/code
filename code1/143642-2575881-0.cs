    var teamIds = User.Where(u => u.UserID == 4).Select(u => u.TeamID).AsEnumerable();
    var groups = ProjectAssociation.Where(pa => teamIds.Contains(pa.TeamID)
       .GroupBy(pa => pa.ProjectID);
    var result = from g in groups
           let count = teamIds.Distinct().Count()
           where g.Count() == count
           select g.Key;
