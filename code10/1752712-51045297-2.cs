    var groups = subsetJoinedItems.GroupBy(joinedItem => new
    {
         ProjectId = joinedItem.Project.Id,
         ProjectName = joinedItem.Project.Name,
         Subject = joinedItem.Issue.Subject,
         Spent_on = joinedItem.TimeEntry.SpentOn,
    });
