    int?[] intData = Enumerable.Range(1, 100).Cast<int?>().ToArray();
    ShiftyArray<int?> array = new ShiftyArray<int?>(intData);
    Stopwatch watch = new Stopwatch();
    watch.Start();
    for(int i = 0; i < 1000000; i++)
    {
        array.ShiftLeft();
    }
    watch.Stop();
    Console.WriteLine(watch.ElapsedMilliseconds);
