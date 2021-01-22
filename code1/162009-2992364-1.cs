    Dictionary<int, string> dictionary = new Dictionary<int, string>();
    dictionary.Add(1, "foo");
    dictionary.Add(2, "foo");
    dictionary.Add(3, "bar");
    string someValue = "foo";
    RemoveByValue(dictionary, someValue);
