    var source = Enumerable.Range(1, 100).Cast<int?>().ToArray();
    var destination = new int?[source.Length];
    var s = new Stopwatch();
    s.Start();
    for (int i = 0; i < 1000000;i++)
    {
        Array.Copy(source, 1, destination, 0, source.Length - 1);
    }
    s.Stop();
    Console.WriteLine(s.Elapsed);
