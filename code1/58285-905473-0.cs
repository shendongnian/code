    Dictionary<string, int> MyDictionary = new Dictionary<string, int>();
    foreach (KeyValuePair<string, int> item in MyDictionary)
    {
      int i = item.Value;
    }
    
    Hashtable MyHashtable = new Hashtable();
    foreach (DictionaryEntry item in MyHashtable)
    {
      // Cast required because compiler doesn't know it's a <string, int> pair.
      int i = (int) item.Value;
    }
