    public IEnumerable<int> FlattenVal()
    {
        yield return this.val;
        foreach (var t2 in this.Tests)
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
