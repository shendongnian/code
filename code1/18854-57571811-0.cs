    public static void Add<K, V>(this Dictionary<K, V> d, Dictionary<K, V> other) {
      foreach (var kvp in other)
      {
        if (!d.ContainsKey(kvp.Key))
        {
          d.Add(kvp.Key, kvp.Value);
        }
      }
    }
  
    var s0 = new Dictionary<string, string> {
      { "A", "X"}
    };
    var s1 = new Dictionary<string, string> {
      { "A", "X" },
      { "B", "Y" }
    };
    // Combine as many dictionaries and key pairs as needed
    var a = new Dictionary<string, string> {
      s0, s1, s0, s1, s1, { "C", "Z" }
    };
