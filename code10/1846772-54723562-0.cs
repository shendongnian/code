    var tasks = new List<Task>();
    
    for (int i = 0; i < threadsNumericUpDown.Value; i++)
    {
        tasks.Add(Task.Run(() => DoJob(i)));
    }
    
    Task.WaitAll(tasks);
