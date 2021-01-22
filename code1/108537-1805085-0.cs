    List<string> list = new List<string>()
      {
        "One",
        "One",
        "Two",
        // etc
      }
    
    Dictionary<string, int> d = new Dictionary<string, int>();
    
    foreach (string s in list)
    {
      if (d.ContainsKey(s))
        d.Add(s, 1);
      else
        d[s]++;
    }
