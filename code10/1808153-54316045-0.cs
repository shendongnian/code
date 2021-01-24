    var tasks = new List<Task>();
    foreach( var e in strEvents )
    {
       tasks.Add(outEventHub.AddAsync(e));
    }
    await Task.WhenAll(tasks);
    await outEventHub.FlushAsync();
