    int count=1;        
    var z = testdict
            .GroupBy(x => new { x.Value.Item2, x.Value.Item3 })
            .ToDictionary(x => ++count, 
                          x => new Tuple<string, string, int>
                               (
                                x.Key.Item2, x.Key.Item3, x.Count()
                                ));
