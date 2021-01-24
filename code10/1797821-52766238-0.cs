    class TaskTest
    {
        private async Task CreatePauseTask(int ms)
        {
            Console.WriteLine($"Start {ms} ms pause");
            await Task.Delay(ms);
            Console.WriteLine($"{ms} ms are elapsed");
        }
    
        public async Task Start()
        {
            var taskList = new List<Task>(new[]
            {
                    CreatePauseTask(1000),
                    CreatePauseTask(2000)
                });
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
