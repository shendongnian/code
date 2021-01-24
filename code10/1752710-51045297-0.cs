    var joinedItems = from timeEntry in timeEntries
        join project in project on timeEntry.ProjectId equals project.Id
        join issue in issues on timeEntry.IssueId equals issue.Id
        select new
        {
            TimeEntry = timeEntry,
            Project = Project,
            Issue = Issue,
        };
