    public IDictionary<int, int> MergeSequences(IEnumerable<int>[] value1ByType, Dictionary<int, int> value2ToType)
    {
        int pos = 0;
        var value1ByTypePos = from byType in value1ByType
                              select new { Pos = pos++, Enumerator = byType.GetEnumerator() };
        return (from byType in value1ByTypePos
                join toType in value2ToType
                on byType.Pos equals toType.Value
                select new { toType.Key, Value = byType.Enumerator.GetNext() })
               .ToDictionary(pair => pair.Key, pair => pair.Value);
    }
