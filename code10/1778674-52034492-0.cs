        public static async Task Do()
        {
            var tasks = new Task[10];
            for (int i = 0; i < 10; i++)
            {
                tasks[i] = Wait(i);
            }
            await Task.WhenAll(tasks);
        }
