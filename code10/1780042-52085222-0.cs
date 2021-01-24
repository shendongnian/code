    List<int> list = new List<int>() { 8, 22, 41};
    int from = 1;
    int upTo = 47;
    var result = list
      .OrderBy(item => item)
      .Concat(new int[] { upTo + 1 }) // add upTo breaking point
      .Select(item => new Tuple<int, int>(from, (from = item) - 1))
      .Where(item => item.Item1 != item.Item2); // degenerated cases (if we have 1 or 47)
    Console.Write(String.Join(Environment.NewLine, result));
