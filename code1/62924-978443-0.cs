    public IEnumerable<T> GetOddStrings(
      IEnumerable<IEnumerable<string>> stringCollections)
    {
        foreach(var stringCollection in stringCollections)
          foreach(var str in stringCollection)
          {
            if(str.Length %2 != 0) yield return str;
            if(str.Length == 42) yield break; // 42 is BAD! Stop immediately
          }
    }
