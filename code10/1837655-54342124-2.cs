    //Async
    Parallel.For(1, 100, async (index) =>
    {
        System.Console.WriteLine("start:" + index);
        await Task.Delay(1000);
        System.Console.WriteLine("ended:" + index);
    });
    //Task.Delay(2000).Wait();
