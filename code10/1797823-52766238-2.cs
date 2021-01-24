    class TaskTest
    {
        private Task CreatePauseTask(int ms)
        {
            return new Task<Task>(async () =>
            {
                Console.WriteLine($"Start {ms} ms pause");
                await Task.Delay(ms);
                Console.WriteLine($"{ms} ms are elapsed");
            }, TaskCreationOptions.DenyChildAttach);
        }
    
        public async Task Start()
        {
            var taskList = new List<Task>(new[]
            {
                    CreatePauseTask(1000),
                    CreatePauseTask(2000)
                });
            taskList.ForEach(t => t.Start(TaskScheduler.Default));
            await Task.WhenAll(taskList);
            Console.WriteLine("------------");
        }
    }
    
    
    static void Main()
    {
        var t = new TaskTest();
        t.Start();
        Console.ReadKey();
    }
