    Task a = AsyncTaskA();
    Task b = AsyncTaskB();
    Task c = AsyncTaskC();
    List<Task> AllTasks = new List<Task>();
    AllTasks.Add(a);
    AllTasks.Add(b);
    AllTasks.Add(c);
    // this will run all your tasks async and parallel and also wait until everything is done
    await Task.WhenAll(AllTasks);
