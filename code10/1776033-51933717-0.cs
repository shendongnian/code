    var tasksA = new List<Task<ApiResponse<string>>>();
    var tasksB = new List<Task<ApiResponse<string>>>();
    
    //fire off all the async tasks
    foreach(var it in iterations){
       tasksA.Add(_Api.TaskA(orderResult.OrderId));
       tasksB.Add(_Api.TaskB(orderResult.OrderId));
    }
    
    //await the results
    await Task.WhenAll(tasksA);
    await Task.WhenAll(tasksB);
    foreach (var task in tasksA)
    {
        //no need to get GetAwaiter(), you've awaited above.
        task.Result;
     }  
