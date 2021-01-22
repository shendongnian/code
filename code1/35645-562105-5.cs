    // Create tasks.
    Task[] tasks = 
    { 
        new Task() { Name = "Task 1", StartTime = new DateTime(2009, 02, 18) },
        new Task() { Name = "Task 2", StartTime = new DateTime(2009, 02, 16) },
        new Task() { Name = "Task 3", StartTime = new DateTime(2009, 02, 12) },
        new Task() { Name = "Task 4", StartTime = new DateTime(2009, 02, 11) },
        new Task() { Name = "Task 5", StartTime = new DateTime(2009, 02, 10) },
        new Task() { Name = "Task 6", StartTime = new DateTime(2009, 02, 01) },
        new Task() { Name = "Task 7", StartTime = new DateTime(2009, 02, 09) }
    };
    
    // Now create the indexer.
    BinarySearcher<Task> searcher = new BinarySearcher<Task>(tasks,
        (x, y) => Comparer<DateTime>.Default.Compare(x.StartTime, y.StartTime));
    
    foreach (Task t in searcher.Between(
        new Task() { StartTime = new DateTime(2009, 02, 13) },
        new Task() { StartTime = new DateTime(2009, 02, 10) }))
    {
        // Write.
        Console.WriteLine(t);
    }
