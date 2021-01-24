    List<Task<bool>> tasks = new List<Task<bool>>();
    //rest of the code 
    if(AObjList.Count > 0)
    {
      //"Task A" state object to idetify its task A
      tasks.Add(Task.Factory.StartNew(()=> insertA(AObjList), "Task A"));
    }
    if(BObjList.Count > 0)
    {
      //"Task B" state object to idetify its task B
      tasks.Add(Task.Factory.StartNew(() => insertB(BObjList), "Task B"));
    } 
    await Task.WhenAll(tasks);
    foreach(var t in tasks)
    {
      Console.WriteLine(t.AsyncState.ToString());
      Console.WriteLine(t.Result);
    }
