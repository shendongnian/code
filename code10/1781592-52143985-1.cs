    public List<string> GetTaskNames(Task task, List<string> tasks = null)
    {
        if(tasks == null);
            tasks = new List<string>();
        tasks.Add(task.Name);
    
        foreach(var child in task.ChildTask)
           GetTaskNames(child, tasks);
    
        return tasks;
    }
    
    var role = context.Roles.Find(roleId);
    var names = role.Tasks.SelectMany(x => GetTaskNames(x)).Distinct().ToList();
