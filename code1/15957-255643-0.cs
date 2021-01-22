    public List<TKey> GetKeysFromValue<TKey, TVal>(Dictionary<TKey, TVal> dict, TVal val)
    {
       List<TKey> ks = new List<TKey>();
       foreach(TKey k in dict.Keys)
       {
          if (dict[k] == val) { ks.Add(k); }
       }
       return ks;
    }
