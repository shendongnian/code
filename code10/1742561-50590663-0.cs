    var ans = src.Aggregate((Count: 0, Min: Int32.MaxValue, Max: Int32.MinValue, Sum: 0),
                            (g, v) => (g.Count+1, v < g.Min ? v : g.Min, v > g.Max ? v : g.Max, g.Sum+v));
    var count = ans.Count;
    var min = ans.Min;
    var max = ans.Max;
    var avg = ans.Sum / ans.Count;
