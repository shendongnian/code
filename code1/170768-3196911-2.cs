    IEnumerable<TestResults> AllResults(IEnumerable<TestResults> results)
    {
        foreach(var tr in results)
        {
            yield return tr;
            foreach(var sr in AllResults(tr.SubTests))
                yield return sr;
        }
    }
