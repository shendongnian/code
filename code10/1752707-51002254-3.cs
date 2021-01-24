    var result = from time in time_entries
        join issue in issues on time.issue_id equals issue.id
        join project in projects on time.project_id equals project.id
        where (new int[] { 26, 27 }).Contains(project.id)
            && !issue.subject.Contains("zlecane")
            && time.spent_on.Split('-')[1] == DateTime.Now.ToString("MM")
        group time by new
        {
            projectName = project.name,
            projectId = project.id,
            issueSubject = issue.subject,
            issueDescription = issue.description,
            timeSpentOn = time.spent_on
        } into g
        select new
        {
            projectName = g.Key.projectName,
            projectId = g.Key.projectId,
            issueSubject = g.Key.issueSubject,
            issueDescription = g.Key.issueDescription,
            timeSpentOn = g.Key.timeSpentOn,
            timeHours = g.Sum(e=>e.hours)
        };
