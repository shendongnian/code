    List<List<TodoTask>> GetTodoTasks(IEnumerable<TodoTask> tasks, int timeWindow)
    {
        List<List<TodoTask>> allTasks = new List<List<TodoTask>>();
        
        List<TodoTask> tasks = new List<TodoTask>();
        int duration = 0;
        
        foreach(TodoTask task in tasks)
        {
            if(duration > timeWindow)
            {
                allTasks.Add(tasks);
                
                duration = 0;
                tasks = new List<TodoTask>();
            }
            
            tasks.Add(task);
            duration += task.Duration;
        }
        allTasks.Add(tasks);        
        return allTasks;
    }
