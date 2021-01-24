    Tuple<decimal, decimal>[] tests = new Tuple<decimal, decimal>[] {
      Tuple.Create(3.10m,  2.8m),
      Tuple.Create( 3.1m,  2.8m),
      Tuple.Create( 3.0m,  2.8m),
      Tuple.Create( 3.0m,  2.0m),
      Tuple.Create(   3m,    2m),
      Tuple.Create( 3.8m,  2.4m),
      Tuple.Create(3.10m, 3.10m),
      Tuple.Create( 2.8m,  2.2m),
      Tuple.Create(2.11m,  2.2m),
    };
    string report = string.Join(Environment.NewLine, tests
      .Select(test => 
         $"{test.Item1,5} + {test.Item2,5} == {EerieArithmetics(test.Item1, test.Item2),5}"));
    Console.Write(report);
