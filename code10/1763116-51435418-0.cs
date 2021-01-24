    var operationTask = SomeOperationAsync(...);
    tasks.Add(operationTask);
    task = Task.WhenAll(tasks);
    if (task.IsCompleted)
    {
        // no operation is going on
        tasks.Clear();
        
        // do what ever you want to do further
    }
    else
    {
         //some operation is going on
    }
    
