    static IEnumerable<int> Test (int i)
    {
        Contract.Requires(i > 0);
        return _Test(i);
    }
    private static IEnumerable<int> _Test (int i)
    {
        for (int j = 0; j < i; j++)
            yield return j;
    }
