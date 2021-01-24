    public static IEnumerable<string> FindAllCombinationsAnotherWay()
    {
        List<int> ListOne = Enumerable.Range(1, 100).ToList();
        List<int> ListTwo = Enumerable.Range(1, 100).ToList();
        var result = ListOne.SelectMany((a, indexA) =>
                 ListTwo.Where((b, indexB) =>
                        ListTwo.Contains(a) ? !b.Equals(a) && indexB > indexA
                                          : !b.Equals(a))
                      .Select(b => string.Format("A{0:00}B{1:00}", a, b)));
        return result.Distinct();
    }
