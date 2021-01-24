    var projects = User.FindAll("projects");
    
    List<int> userProjectIds = new List<int>();
    
    foreach (var project in projects)
    {
        userProjectIds.Add(Int32.Parse(project.Value));
    }
