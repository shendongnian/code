    [Tested]
    public virtual bool ContainsAll<U>(SCG.IEnumerable<U> items) where U : T
    {
      HashBag<T> res = new HashBag<T>(itemequalityComparer);
      foreach (T item in items)
        if (res.ContainsCount(item) < ContainsCount(item))
          res.Add(item);
        else
          return false;
      return true;
    }
    
