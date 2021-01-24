    Task[] allTasks = new Task[] {taskDoSomething, taskDoSomethingElse);
    await Task.WhenAll(allTasks);
    var someResult = taskDoSomething.Result;
    var someOtherResult = taskDoSomethingElse.Result;
    ProcessBothResults(someResult, someOtherResult);
