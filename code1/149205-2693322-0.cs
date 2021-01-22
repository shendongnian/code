    Task<List<string>> task1 = new Task<List<string>>(SomeFunction);
    Task<List<string>> task2 = new Task<List<string>>(SomeFunction);
    task1.Start();
    task2.Start();
    var taskList = new List<Task<List<string>>> {task1, task2};
    Task.WaitAll(taskList.ToArray());
    List<string> res = new List<string>();
    foreach (Task<List<string>> t in taskList)
    {
        res.AddRange(t.Result);
    }
