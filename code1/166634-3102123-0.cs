    Hashtable hashtable = GetYourHashtable();
    var result = new List<DictionaryEntry>(hashtable.Count);
    foreach (DictionaryEntry entry in hashtable)
    {
        result.Add(entry);
    }
    result.Sort(
        (x, y) =>
        {
            IComparable comparable = x.Value as IComparable;
            if (comparable != null)
            {
                return comparable.CompareTo(y.Value);
            }
            return 0;
        });
    foreach (DictionaryEntry entry in result)
    {
      Console.WriteLine(entry.Key.ToString() + ":" + entry.Value.ToString());
    }
