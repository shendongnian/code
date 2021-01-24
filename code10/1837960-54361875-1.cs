    public static async Task Do()
    {
        Task<int[]> parent = Task.Factory.StartNew
        (
            () =>
            {
                var results = new int[3];
                Task.Factory.StartNew(() => results[0] = 0, default(CancellationToken), TaskCreationOptions.AttachedToParent, TaskScheduler.Default);
                Task.Factory.StartNew(() => results[1] = 1, default(CancellationToken), TaskCreationOptions.AttachedToParent, TaskScheduler.Default);
                Task.Factory.StartNew(() => results[2] = 2, default(CancellationToken), TaskCreationOptions.AttachedToParent, TaskScheduler.Default);
                return results;
            }
        , default(CancellationToken), TaskCreationOptions.None, TaskScheduler.Default);
        var ints = await parent;
        foreach (var i in ints)
        {
            Console.WriteLine("res {0}", i);
        }
    }
