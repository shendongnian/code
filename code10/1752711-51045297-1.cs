    int currentMonth = DateTime.Now.Month;
    var subsetJoinedItems = joinedItems.Where(joinedItem =>
       (joinedItem.Project.Id == 26 || joinedItem.Project.Id == 27)
       && joinedItem.Issue.Subject.Contains("zlecane")   // consider ignore case
       && joinedItem.TimeEntry.SpentOn.Month == currentMonth);
