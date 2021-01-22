    List<TimeSpan> input = Enumerable.Range(0, 500)
                                     .Select(i => new TimeSpan(0, 0, i))
                                      .ToList();
    var res = input.Select((t, i) => new { time=t.Ticks, index=i })
                   .GroupBy(v => v.index / 10, v => v.time)
                   .Select(g => new TimeSpan((long)g.Average()));
    int n = 0;
    foreach (var t in res) {
        Console.WriteLine("{0,3}: {1}", ++n, t);
    }
