    public void FindMissing(IEnumerable<int> values)
    {
      HashSet<int> myRange = new HashSet<int>(Enumerable.Range(0,10));
      var missing = myRange.ExceptWith(values);
    }
