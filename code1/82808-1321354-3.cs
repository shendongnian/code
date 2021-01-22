    var result = 1234567
        .ToString()
        .Select((c, index) => Tuple.Create( index % 2 == 1, Char.GetNumericValue(c))
        .GroupBy(d=>d.Item1)
        .Select(g => new { OddColumns = g.Key, Sum = g.Sum(item => item.Item2) });
    foreach( var r in result )
        Console.WriteLine(r);
