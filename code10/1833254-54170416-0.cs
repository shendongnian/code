    var tasks = new List<Task>();
    foreach (Models.Channel.IChannel channel in channels)
    {
        Task myTask = Task.Run(...); // create your task here
        tasks.Add(myTask);
    }
    
    try
    {
        Task.WaitAll(tasks.ToArray(), TimeSpan.FromSeconds(5));
    }
    catch
    {
        // Insert Exception handling logic
    }
