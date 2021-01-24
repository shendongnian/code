        public static async Task SomeAsyncTask()
        {
            await Task.Delay(5000);
            Console.WriteLine("2222");
        }
        public static async Task Loop()
        {
            var collection = new[] { 1, 2, 3, 4 };
            var asyncTasks = new Task[4];
            Parallel.ForEach(collection,
                (item, loop, index) =>
                {
                    Console.WriteLine("1111");
                    asyncTasks[index] = SomeAsyncTask();
                });
            await Task.WhenAll(asyncTasks);
        }
