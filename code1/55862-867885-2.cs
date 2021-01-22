    public static void Add<TKey, TList, TValue>(
        this IDictionary<TKey, TList> lookup,
        TKey key, TValue value)
        where TList : class, ICollection<TValue>, new()
    {
        TList list;
        if (!lookup.TryGetValue(key, out list))
        {
            lookup.Add(key, list = new TList());
        }
        list.Add(value);
    }
    static void Main() {
        var data = new Dictionary<string, List<string>>();
        data.Add("abc", "def");
    }
