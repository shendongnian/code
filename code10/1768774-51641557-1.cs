        public async Task RunTasksConcurrently()
        {
            IList<Task> tasks = new List<Task>();
            for (int i = 0; i < 10; i++)
            {
                tasks.Add(Task.Run(async () => await Task.Delay(500)));
            }
            foreach (var task in tasks)
            {
                await task;
            }
        }
