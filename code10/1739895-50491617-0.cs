    public void DoWork()
    {
        var tasks = new List<Task>();
        tasks.Add(Task.Run(() => HeavyOperation()));
        tasks.Add(Task.Run(() => HeavyOperation2()));
        tasks.Add(Task.Run(() => HeavyOperation3()));
    
        Task.WaitAll(tasks.ToArray());
    }
