    private static void LoopData(Data data)
    {
        Task.Factory.StartNew((state) =>
        {
            var taskData = (Data)state;
            while (!cancellationTokenSource.IsCancellationRequested)
            {
                Console.WriteLine($"Value: {taskData.Value}\tText: {taskData.Text}");
                Task.Delay(100).Wait();
            }
        },
        data,
        cancellationTokenSource.Token,
        TaskCreationOptions.LongRunning,
        TaskScheduler.Default);
    }
