    public Task GetAll(){
        List<Task> allTasks = _context.Tasks.ToList();
        foreach(var task in allTasks)
            task.LoadDependentTasks(_context.Tasks);
        return allTasks;
    }
