    var result = listOfPairs.SelectMany(pair =>
                 {
                     DateTime s = pair.Item1;
                     DateTime e = pair.Item2;
                     return Enumerable.Range(0, (e - s).TotalDays)
                                      .Select(_ => s.AddDays(value));
                 });
