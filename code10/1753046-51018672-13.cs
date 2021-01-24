    private Tuple<List<int>, List<int>> GenerateData(int scale)
    {
       return new Tuple<List<int>, List<int>>(
          Enumerable.Range(0, scale)
                    .Select(x => x)
                    .ToList(),
          Enumerable.Range(0, scale)
                    .Select(x => Rand.Next(10000))
                    .ToList());
    }
