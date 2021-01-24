    var clientTasks = new List<Task>();
    foreach(var client in clients)
    {
        if (list[i] == 0)
            clientTasks.Add(DoSomethingWithClientAsync());
        else
            clientTasks.Add(DoOtherThingAsync());
    }
    // if here: all tasks started. If desired you can do other things:
    AndNowForSomethingCompletelyDifferent();
    // later we need the other tasks to be finished:
    var taskWaitAll = Task.WhenAll(clientTasks);
    // did you notice we still did not await yet, we are still in business:
    MontyPython();
    // okay, done with frolicking, we need the results:
    await taskWaitAll;
    DoOtherWork();
    
