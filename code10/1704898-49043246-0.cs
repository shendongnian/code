    List<Task> tasks = new List<Task>();
    for (int i = 0; i < 10; i++) //your loop
    {
        var task = Task.Factory.StartNew(() => DoWork1()).ContinueWith((t1) => DoWork2()).ContinueWith(t2 => DoWork3());
        tasks.Add(task);
    }
    Task.WaitAll(tasks.ToArray());
