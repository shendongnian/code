    StringDictionary dictionary = new StringDictionary();
    dictionary.Add("1", "One");
    dictionary.Add("2", "Two");
    dictionary.Add("3", "Three");
    DictionaryEntry[] sortedDictionary = new DictionaryEntry[dictionary.Count];
    dictionary.CopyTo(sortedDictionary, 0);
    Comparison<DictionaryEntry> comparison = new Comparison<DictionaryEntry>(delegate (DictionaryEntry obj1, DictionaryEntry obj2) { return ((string)obj1.Value).CompareTo((string)obj2.Value); });
    Array.Sort(sortedDictionary, comparison);
