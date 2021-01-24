    var allTasks = new List<Task>();
    foreach (var t in things)
    {
        allTasks.Add(My.MethodAsync(t); // method returns Task
        allTasks.Add(My.OtherAsync(t); // method returns Task
    }
    await Task.WhenAll(t).ConfigureAwait(false);
