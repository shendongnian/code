    static void Main(string[] args)
        {
            var tasks = new List<Task>();
            for (var nI = 0; nI < 100; nI++)
            {
                var fathers = new List<Father> { new Father { Id = Guid.NewGuid() } };
                var split = new SplitService();
                var task = new Task(() => split.Split(fathers));
                tasks.Add(task);
            };
            foreach (var task in tasks)
            {
                task.Start();
            }
            Console.ReadKey();
        }
