    var tracker = new TaskTracker();
    tracker.AddTask(new Task("Task 1"));
    tracker.AddTask(new Task("Task 2"));
    
    var taskList = new List<Task>();
    taskList.Add(new Task("Task 3"));
    taskList.Add(new Task("Task 4"));
    
    tracker.AddTasks(taskList);
