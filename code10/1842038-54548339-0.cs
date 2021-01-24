    var projectCollection = JsonConvert.DeserializeObject<Project>(jsonProjectCollection);
    var projects= project.value;
    int count = projectCollection .count;
    foreach(var project in projects.value)
    {
       Console.WriteLine(project.name);
    }
    Console.WriteLine(count);
    Console.WriteLine(projectname);
