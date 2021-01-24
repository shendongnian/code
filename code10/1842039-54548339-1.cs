    var projectCollection = JsonConvert.DeserializeObject<Project>(jsonProjectCollection);
    var projects= projectCollection.value;
    int count = projectCollection .count;
    foreach(var project in projects)
    {
       Console.WriteLine(project.name);
    }
    Console.WriteLine(count);
    Console.WriteLine(projectname);
