    int n = 200;
    IReadOnlyList<double> list = Enumerable.Range(0, n).Select(x=>(double)x).ToList();
    IEnumerable<double> enumerable = Enumerable.Range(10, n).Select(x => (double)x);
    var result = list
        .Zip(enumerable, Tuple.Create)
        .OrderBy(x=>x.Item1)
        .ThenBy(x=>x.Item2)
        .ToList();
    var parallelResult = list
        .AsParallel()
        .AsOrdered()
        .Zip(enumerable.AsParallel().AsOrdered(), Tuple.Create)
        .OrderBy(x => x.Item1)
        .ThenBy(x => x.Item2)
        .ToList();
    parallelResult.ShouldBe(result);
