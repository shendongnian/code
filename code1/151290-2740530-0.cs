    var result = CallMethod(); // This will JIT the method
    var sw = Stopwatch.StartNew();
    for (int i = 0; i < 5; i++)
    {
        result = CallMethod();
    }
    sw.Stop();
    Console.WriteLine(result);
    Console.WriteLine(TimeSpan.FromTick(sw.ElapsedTicks / 5));
