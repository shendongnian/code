    var parallelA = new List<IMyTask>();
    parallelA.Add(new MyTask());
    parallelA.Add(new MyTask());
    
    var task1 = Task.Run(() => Parallel.ForEach(parallelA, task =>
       {
          task.Invoke();
       }));
    
    var parallelB = new List<IMyTask>();
    parallelB.Add(new MyTask());
    parallelB.Add(new MyTask());
    
    var task2 = Task.Run(() => Parallel.ForEach(parallelB, task =>
       {
          task.Invoke().Wait();
       }));
    
    await Task.WhenAll(task1, task2);
