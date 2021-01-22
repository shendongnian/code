    // value is TValue to insert
    List<TValue> list;
    if(!dictionary.TryGetValue(key, out list)) {
        list = new List<TValue>();
        dictionary.Add(key, list);
    }
    list.Add(value);
