    readonly List<Task<T>> _taskList = new List<Task<T>>();
    void fireThreads()
    {
        var timer = Stopwatch.StartNew();
        var taskLoop = Task.Factory.StartNew(()=> DO STUFF);
        _taskList.Add(taskLoop);
        while(await Task.WhenAll(TaskList))
        {
            if (timer.ElapsedMilliseconds / 1000 > TargetTime)
                fireThreads();
        }
    }
