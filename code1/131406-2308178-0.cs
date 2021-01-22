    public IEnumerable<int> GetLimitedIntegers(int limit)
    {
        foreach (int i in Enumerable.Range(1, 10))
        {
            if (i < limit)
                yield return i;
            else
                yield break;
        }
    }
