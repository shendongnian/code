    public void ProcessDelegates(IList<Action> thingsToDo)
    {
        var tasks = thingsToDo.Select(
            ttd => Task.Factory.StartNew(ttd, TaskCreationOptions.PreferFairness)
        ).ToArray();
        Task.WaitAll(tasks);
    }
