        static void Main()
        {
            var data = new Dictionary<string, List<string>>(
                StringComparer.InvariantCultureIgnoreCase);
            data.Add("abc", "def");
            data.Add("abc", "ghi");
        }
        static void Add<TKey, TValue>(this IDictionary<TKey, List<TValue>> lookup,
            TKey key, TValue value)
        {
            List<TValue> list;
            if (!lookup.TryGetValue(key, out list))
            {
                list = new List<TValue>();
                lookup.Add(key, list);
            }
            list.Add(value);
        }
