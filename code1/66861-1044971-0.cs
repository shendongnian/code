    public void Foo(object[] values)
    {
        var pairs = values.OfType<KeyValuePairType>().ToArray();
        var lists = values.OfType<KeyValueListPair>().ToArray();
        pairs = pairs.Length == 0 ? null : pairs;
        lists = lists.Length == 0 ? null : lists;
        DoSomeWork(pairs, lists);
    }
