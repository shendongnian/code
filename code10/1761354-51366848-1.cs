    public static IEnumerable<List<T>> foo()
    {
        List<T> bar = new List<T>();
        List<T> buzz = new List<T>();
        List<T> bazz = new List<T>();
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
