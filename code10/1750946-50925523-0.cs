    List<Task> tasks = new List<Task>();
    if(AObjList.Count > 0)
    {
      tasks.Add(insertA(AObjList));
    }
    
    if(BObjList.Count > 0)
    {
      tasks.Add(insertB(BObjList));
    } 
    
    await Task.WhenAll(tasks);
    if (tasks.Any(t => !t.Result))
    {
      return false;
    }
