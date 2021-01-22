    public void Test
    {
      Dictionary<string, object> objectList = new Dictionary<string, object>();
      Dictionary<string, object> guidList = new Dictionary<string, Guid>();
      IterateGenericDict(objectList);
      IterateGenericDict(guidList);
    }
    public void IterateGenericDict(object obj)
    {
      foreach (DictionaryEntry entry in (IDictionary)obj)
      {                    
        Console.WriteLine(entry.Key + "=" entray.Value.ToString());
      }
    }
