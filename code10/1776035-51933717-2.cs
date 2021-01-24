    var tasksA = new List<Task<ApiResponse<string>>>();
    var tasksB = new List<Task<ApiResponse<string>>>();
    
    //fire off all the async tasks
    foreach(var it in iterations){
       tasksA.Add(_Api.TaskA(orderResult.OrderId));
       tasksB.Add(_Api.TaskB(orderResult.OrderId));
    }
    
    //await the results
    await Task.WhenAll(tasksA).ConfigureAwait(false);
    foreach (var task in tasksA)
    {
        //no need to get GetAwaiter(), you've awaited above.
        task.Result;
    } 
    //to get the most out of the async only await them just before you need them
    await Task.WhenAll(tasksB).ConfigureAwait(false);
    
    foreach (var task2 in tasksB)
    {
         task2.Result;
    }
