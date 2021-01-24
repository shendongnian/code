    public static IEnumerable<IEnumerable<T>> Combinations<T>(IList<T> items)
    {
        return Combinations(items.Count).Select(comb => comb.Select(index => items[index]));
    }
    public static IEnumerable<IEnumerable<int>> Combinations(int n)
    {
        long m = 1 << n;
        for (long i = 1; i < m; ++i)
            yield return bitIndices((uint)i);
    }
    static IEnumerable<int> bitIndices(uint n)
    {
        uint mask = 1;
        for (int bit = 0; bit < 32; ++bit, mask <<= 1)
            if ((n & mask) != 0)
                yield return bit;
    }
