    var result = groups.Select(group => new
    {
        ProjectId = group.Key.ProjectId,
        ProjectName = group.Key.ProjectName,
        Subject = group.Key.Subject,
        SpentOn = group.Key.SpentOn,
        // remaining properties: SQL query seems incorrect
        ...
    });
  
