    // The source of your work items, create a sequence of Task instances.
    Task[] tasks = Enumerable.Range(0, 100).Select(i =>
        // Create task here.
        Task.Run(() => {
            // Do work.
        })
    
        // No signalling, no anything.
    ).ToArray();
    // Wait on all the tasks.
    Tasks.WaitAll(tasks);
