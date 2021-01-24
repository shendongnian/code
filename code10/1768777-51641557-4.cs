        public void SpawnInitialTasks()
        {
            for (int i = 0; i < 3; i++)
            {
                RunNextTask();
            }
        }
        public void RunNextTask()
        {
            Task.Run(async () => await Task.Delay(500))
                .ContinueWith(t => RunNextTask());  
            // Recurse here to keep running tasks whenever we finish one.
        }
