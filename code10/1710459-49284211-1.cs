    var delays = Enumerable.Repeat(100, 24).Concat(Enumerable.Repeat(2000, 4)).ToArray();
    var partitioner = Partitioner.Create(delays, EnumerablePartitionerOptions.NoBuffering);
    Parallel.ForEach(partitioner, new ParallelOptions {MaxDegreeOfParallelism = 4}, d =>
    {
        Thread.Sleep(d);
        Console.WriteLine("Done with " + d);
    });
