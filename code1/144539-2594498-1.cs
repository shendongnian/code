    IEnumerable<IEnumerable<int>> sequences(IEnumerable<int> set, int maxTotal)
    {
        foreach (int i in set.Where(x => x <= maxTotal))
        {
            yield return new int[] { i };
            foreach (var s in sequences(set.Where(x => x <= i), maxTotal - i))
                yield return (new int[] { i }).Concat(s);
        }
    }
    void Run()
    {
        foreach (var z in sequences(new int[] { 3, 2, 1 }, 10))
            Console.WriteLine(
                string.Join(" ", z.Select(x => x.ToString()).ToArray())
            );
    }
