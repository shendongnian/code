    var sortedTasks = from task in tasks
                      orderby 1
                      select task;
    if (userWantsToSortByAssignedTo == true)
    {
        if (sortByAssignedToDescending == true)
            sortedTasks = sortedTasks.ThenByDescending(t => t.AssignedTo);
        else
            sortedTasks = sortedTasks.ThenBy(t => t.AssignedTo);
    }
