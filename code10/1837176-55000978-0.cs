    var projects = await jira.Projects.GetProjectsAsync();
    
     foreach (var project in projects)
                {
                    System.Console.WriteLine(project.Name);
                }
