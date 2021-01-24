    //need to specify the return type here
    List<Task<bool>> tasks = new List<Task<bool>>();
    if(AObjList.Count > 0)
    {
      tasks.Add(insertA(AObjList));
    }
    
    if(BObjList.Count > 0)
    {
      tasks.Add(insertB(BObjList));
    } 
    
    //await the result as usual
    await Task.WhenAll(tasks);
    
    //you can only use Result here because you've awaited. Never use this without await 
    //as this can cause deadlocks
    return tasks.All(a => a.Result);
