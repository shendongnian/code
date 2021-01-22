    Stopwatch sw = Stopwatch.StartNew();
    var q = new ConcurrentQueue<Tuple<int, int, int>>();
    Enumerable.Range(0, 10000000).AsParallel().ForAll(i => q.Enqueue(Tuple.Create(i, i, i)));
    Console.WriteLine(sw.ElapsedMilliseconds);
    Console.ReadLine();
