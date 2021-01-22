    public IEnumerable<string> GetStrings
      (KeyValuePair<string, List<string>> kvp)
    {
      List<string> result = new List<string>();
      result.Add(kvp.Key);
      result.AddRange(kvp.Value.Select(s => "\t" + s));
      return result;
    }
