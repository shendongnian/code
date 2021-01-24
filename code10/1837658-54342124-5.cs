    //Sync
    Parallel.For(1, 100, (index) =>
    {
        System.Console.WriteLine("start:" + index);
        Task.Delay(1000).Wait();
        System.Console.WriteLine("ended:" + index);
    });
