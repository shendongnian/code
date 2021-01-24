    public static
    class TaskExtensions
    {
        public static async
        Task ContinueWith(this Task task, Func<Task> continuation)
        {
            await task;
            await continuation();
        }
    }
    class Program
    {
        static readonly Dictionary<string, Task> _currentTasks = new Dictionary<string, Task>();
        private static
        Task WrapMessageInQueue(string serviceNumber, Func<Task> taskFunc)
        {
            lock (_currentTasks)
            {
                if (!_currentTasks.TryGetValue(serviceNumber, out var task))
                    task = Task.CompletedTask;
                return _currentTasks[serviceNumber] = task.ContinueWith(() => taskFunc());
            }
        }
        public static
        void Main(string[] args)
        {
            Task.Run(async () =>
            {
                var task1 = WrapMessageInQueue("10", async () =>
                {
                    await Task.Delay(500);
                    Console.WriteLine("first task finished");
                });
                var task2 = WrapMessageInQueue("10", async () =>
                {
                    Console.WriteLine("second task finished");
                });
                await Task.WhenAll(new[] { task1, task2 });
            }).Wait();
        }
    }
