    List<KeyValuePair<int, string>> pairs = new List<KeyValuePair<int, string>>();
    pairs.Add(new KeyValuePair<int, string>(1, "Miroslav"));
    pairs.Add(new KeyValuePair<int, string>(2, "Naomi"));
    pairs.Add(new KeyValuePair<int, string>(2, "Ingrid"));
    Dictionary<int, string> dict = new Dictionary<int, string>();
    dict.Add(1, "Miroslav");
    dict.Add(2, "Naomi");
    dict.Add(2, "Ingrid"); // System.ArgumentException: An item with the same key has already been added.
