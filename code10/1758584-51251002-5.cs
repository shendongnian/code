    const string RESERVED_TASK_NAME_1 = "Reserved Task Name 1";
    const string RESERVED_TASK_NAME_2 = "Reserved Task Name 2";
    
    var tracker = new TaskTracker();
    tracker.AddTask(new Task("Task 1"));
    tracker.AddTask(new Task("Task 2"));
    
    var taskList = new List<Task>();
    taskList.Add(new Task(RESERVED_TASK_NAME_1));
    taskList.Add(new Task(RESERVED_TASK_NAME_2));
    
    tracker.AddTasks(taskList);
    
    var taskFromLookup = tracker.GetTask(RESERVED_TASK_NAME_1);
    
    tracker.AddTask(new DerivedTask1());
    var otherTaskFromLookup = tracker.GetTask(DerivedTask1.TASK_NAME);
