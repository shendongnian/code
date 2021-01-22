    System.Collections.IDictionaryEnumerator enumerator = hashTable.GetEnumerator();
    
    while (enumerator.MoveNext())
    {
        string key = enumerator.Key.ToString();
        string value = enumerator.Value.ToString();
    
        Console.WriteLine(("Key = '{0}'; Value = '{0}'", key, value);
    }
