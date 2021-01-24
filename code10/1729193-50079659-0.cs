    static async Task Test()
    {
        Queue<int> ids = new Queue<int>(Enumerable.Range(0, 100));
        List<Task> tasks = new List<Task>();
        for (int i = 0; i < 8; i++)
        {
            tasks.Add(DoTheThings(ids));
        }
        await Task.WhenAll(tasks);
    }
    static async Task DoTheThings(Queue<int> ids)
    {
        Random rnd = new Random();
        int id;
        for (;;)
        {
            lock (ids)
            {
                if (ids.Count == 0)
                {
                    // All done.
                    return;
                }
                id = ids.Dequeue();
            }
            Debug.WriteLine($"Fetching ID {id}...");
            // Simulate variable network delay.
            await Task.Delay(rnd.Next(200) + 50);
        }
    }
