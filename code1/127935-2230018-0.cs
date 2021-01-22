    // dict is OrderedDictionary
    object[] keys = new object[dict.Keys.Count];
    dict.Keys.CopyTo(keys, 0);
    for(int i = 0; i < dict.Keys.Count; i++) {
        Console.WriteLine(
            "Index = {0}, Key = {1}, Value = {2}",
            i,
            keys[i],
            dict[i]
        );
    }
