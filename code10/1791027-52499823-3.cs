      Tuple<DateTime, DateTime>[] test = new Tuple<DateTime, DateTime>[] {
        Tuple.Create(new DateTime(2018, 01, 01), new DateTime(2018, 01, 02)),
        Tuple.Create(new DateTime(2018, 02, 15), new DateTime(2018, 03, 21)),
        Tuple.Create(new DateTime(2018, 01, 10), new DateTime(2018, 01, 10)),
        Tuple.Create(new DateTime(2018, 01, 03), new DateTime(2018, 01, 09)),
      };
      var result = Accumulate(test)
        .ToList();
      string report = string.Join(Environment.NewLine, result
        .Select(item => $"({item.Item1:yyyy'/'MM'/'dd}, {item.Item2:yyyy'/'MM'/'dd})"));
