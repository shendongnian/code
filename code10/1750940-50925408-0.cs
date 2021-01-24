    List<Task<bool>> tasks = new List<Task<bool>>();
    //rest of the code 
    if(AObjList.Count > 0)
    {
      tasks.Add(Task.Factory.StartNew(()=> insertA(AObjList)));
    }
    if(BObjList.Count > 0)
    {
      tasks.Add(Task.Factory.StartNew(() => insertB(BObjList)));
    } 
    await Task.WhenAll(tasks);
    foreach(var t in tasks)
      Console.WriteLine(t.Result);
