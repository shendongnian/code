    public static IEnumerable<int> FlattenVal(this Test1 t1)
    {
        yield return t1.val;
        foreach (var t2 in t1.Tests)
        {
            yield return t2.val;
            foreach (var t3 in t2.Tests)
            {
                yield return t3.val;
                foreach (var t4 in t3.Tests)
                {
                    yield return t4.val;
                }
            }
        }
    }
