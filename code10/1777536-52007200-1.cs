    static void RunTasks()
    {
        List<Task> tasks = new List<Task>();
        for (int i = 0; i < NUM_TASKS; i++)
        {
            tasks.Add(BeginTaskAsync(i));
        }
        
        // Your long-term goal should be to replace this with await Task.WhenAll(tasks);
        Task.WaitAll(tasks);
    }
    
    // work down your call stack here and convert methods to use async/await,
    // eventually calling await ExecuteAsync() from the Google lib...
        
    static async Task BeginTaskAsync(int taskIndex)
    {
        ...
        await ThreadLoopAsync(taskIndex);
    }
    static async Task ThreadLoopAsync(int taskIndex)
    {
        Random random = new Random(taskIndex);
        while (true)
        {
            try
            {
                await GoogleDrive.TestAsync(random);
            }
            ...
        }
    }
        
    class GoogleDrive
    {
        ...
        public static async Task TestAsync(Random random)
        {
            ...
            using (DriveService service = GetDriveService(user))
            {
                var request = service.Files.List();
                var result = await request.ExecuteAsync();
            }
        }
    }
