    var tasks = new List<Task<int>>();
    for(int i=1; i<=5; i++)
    {
        tasks.Add(DoSomething(i));
    }
    foreach (var task in tasks)
    {
        var result = await task;
        Console.WriteLine(result);
    }
