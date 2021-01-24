    var tasks = new List<Task>();
    tasks.Add(new Task(DoEncryption));
    tasks.Add(new Task(DoEncryption));
    tasks.Add(new Task(DoEncryption));
    tasks.Add(new Task(DoEncryption));
    tasks.Add(new Task(DoEncryption));
    Task.WhenAll(tasks);
    
