    Task.Run(() =>
    {
        var url = new Uri(_tfsUrl);
        var cred = new VssClientCredentials();
        projectCollection = new TfsTeamProjectCollection(url, cred);
        workItems = projectCollection.GetService<WorkItemStore>();
    }).Wait();
    project = workItems.Projects["Job Posting Data"];
    defaultType = project.WorkItemTypes["Bug"];
    taskType = project.WorkItemTypes["Task"];
