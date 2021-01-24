    const TaskList = new List<Task<T>>();
    void fireThreads()
    {
     var timer = Stopwatch.StartNew();
     var taskLoop = Task.Factory.StartNew(()=> DO STUFF);
     TaskList.Add(taskLoop);
     While(await Task.WhenAll(TaskList))
     {
      if (timer.ElapsedMilliseconds / 1000 > TargetTime)
       fireThreads();
     }
    }
