    .GroupBy(row => row.ReferenceId)
    .Select(group => new NewSomeGroup() 
    {
        ReferenceId = group.Key,
        SbNotificationList = group       // from the rows in the group make one list
            .Select(row => new Some()    // where every row becomes one Some object
            {
                Title = row.Title,
                ProjectId = row.ProjectId,
                ...
                CreateOnUtc = row.CreateOnUtc, 
             })
             .ToList(),
    })
    .OrderBy(item => item.ReferenceId);
