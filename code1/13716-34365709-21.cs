     var person = new Person
     {
         ...
     };
     for (var i = 0; i < 1000000; i++)
     {
        personList.Add(person);
     }
     var watcher = new Stopwatch();
     watcher.Start();
     var copylist = personList.Select(CopyFactory.CreateCopyReflection).ToList();
     watcher.Stop();
     var elapsed = watcher.Elapsed;
