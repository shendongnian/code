    var result = TimeEntries.Where(timeEntry =>
        (timeEntry.ProjectId == 26 || timeEntry.ProjectId == 27)
           && timeEntry.Issue.Subject.Contains("zlecane")   // consider ignore case
           && TimeEntry.SpentOn.Month == currentMonth)
        .GroupBy(timeEntry => new
        {
            ProjectId = joinedItem.Project.Id,
            ProjectName = joinedItem.Project.Name,
            Subject = joinedItem.Issue.Subject,
            Spent_on = joinedItem.TimeEntry.SpentOn,
        })
        .Select(group => new
        {
            ProjectId = group.Key.ProjectId,
            ProjectName = group.Key.ProjectName,
            Subject = group.Key.Subject,
            SpentOn = group.Key.SpentOn,
            ...
         });
