    for (var i = 0; i < 1000000; i++)
    {
        personList.Add(new Person { Age = 12, Name = "Bob", Weight = 213, FavouriteDay = new DateTime(2000, 1, 1) });
    }        
        var watcher = new Stopwatch();
        watcher.Start();
        var copylist = personList.Select(CopyFactory.CreateCopyReflection).ToList();
        watcher.Stop();
        var elapsed = watcher.Elapsed;
