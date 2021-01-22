    void Example1()
    {
      var collection = new Dictionary<string, string>();
      collection.Add("key1", "value1");
      collection.Add("key2", "value2");
      foreach (var kvp in collection)
      {
        collection = new Dictionary<string, string>();
        Console.WriteLine(kvp);
      }
    }
    
    void Example2()
    {
      var collection = new Dictionary<string, string>();
      collection.Add("key1", "value1");
      collection.Add("key2", "value2");
      foreach (var kvp in collection)
      {
        collection.Clear();
        Console.WriteLine(kvp);
      }
    }
