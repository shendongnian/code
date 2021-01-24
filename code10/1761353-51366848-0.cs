    public static IEnumerable<List<int>> foo()
    {
        List<int> bar = new List<int>();
        List<int> buzz = new List<int>();
        List<int> bazz = new List<int>();
        foreach (var item in someList)
        {
            if (condition1)
            {
                bar.Add(item);
            }
            if (condition2)
            {
                buzz.Add(item);
            }
            if (condition3)
            {
                bazz.Add(item);
            }
        }
        yield return bar;
        yield return buzz;
        yield return bazz;
    }
