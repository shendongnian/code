    static void Main(string[] args)
    {
        Console.WriteLine($"ThreadId={ThreadId}: Main");
        // No need for Task.Run here.
        var task = Process("https://duckduckgo.com", "https://stackoverflow.com/");
        task.Wait();
    }
    private static async Task Process(params string[] urls)
    {
        // Set up initial dictionary mapping task (per URL) to the URL used.
        HttpClient client = new HttpClient();
        var tasks = urls.ToDictionary(u => client.GetAsync(u), u => u);
        while (true)
        {
            // Wait for any task to complete, get its URL and remove it from the current tasks.
            var firstCompletedTask = await Task.WhenAny(tasks.Keys);
            var firstCompletedUrl = tasks[firstCompletedTask];
            tasks.Remove(firstCompletedTask);
            // Do work with completed task.
            try
            {
                Console.WriteLine($"ThreadId={ThreadId}: URL={firstCompletedUrl}");
                using (var response = await firstCompletedTask)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"ThreadId={ThreadId}: Length={content.Length}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ThreadId={ThreadId}: Ex={ex}");
            }
            // Queue the task again.
            tasks.Add(client.GetAsync(firstCompletedUrl), firstCompletedUrl);
        }
    }
    private static int ThreadId => Thread.CurrentThread.ManagedThreadId;
