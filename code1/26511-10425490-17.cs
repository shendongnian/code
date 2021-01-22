    foreach (var item in Enumerable.Range(1, int.MaxValue)
                   .Select(x => x + new string('x', 100000))
                   .Clump(10000).Skip(100).First())
    {
       Console.Write('.');
    }
    // OutOfMemoryException
