    class SomeType { }
    static void Main()
    {
        var items = new Dictionary<long, Dictionary<int, SomeType>>();
        items.Add(12345, 123, new SomeType());
    }
    public static void Add<TOuterKey, TDictionary, TInnerKey, TValue>(
            this IDictionary<TOuterKey,TDictionary> data,
            TOuterKey outerKey, TInnerKey innerKey, TValue value)
        where TDictionary : class, IDictionary<TInnerKey, TValue>, new()
    {
        TDictionary innerData;
        if(!data.TryGetValue(outerKey, out innerData)) {
            innerData = new TDictionary();
            data.Add(outerKey, innerData);
        }
        innerData.Add(innerKey, value);
    }
