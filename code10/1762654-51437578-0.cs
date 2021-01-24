    var tasks = new task[] 
    {
        Task.Run(someMethod),
        Task.Run(someMethod1),
        Task.Run(someMethod2),
        Task.Run(someMethod3),
    };
    
    bool allTasksAreCompleted = Task.WaitAll(tasks, 10000);
    
    if (!allTasksAreCompleted)
    {
        var incompleteTasks = tasks.Where(t => !t.IsCompleted);
    }
