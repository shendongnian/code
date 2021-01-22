    //implement this one implicitly, as it's useful.
    public int Count
    {
      return _list.Count;
    }
    //do a half-and-half on the indexer
    public string this[int index]
    {
      get
      {
        return _list[index];
      }
    }
    string IList<string>.this[int index]
    {
      get
      {
        return this[index];
      }
      set
      {
        throw new NotSupportedException("Collection is read-only.");
      }
    }
    //hide some pointless ones.
    bool ICollection<string>.IsReadOnly
    {
      get
      {
        return true;
      }
    }
    void IList<string>.Insert(int index, string item)
    {
      throw new NotSupportedException("Collection is read-only.");
    }
    void IList<string>.RemoveAt(int index)
    {
      throw new NotSupportedException("Collection is read-only.");
    }
    void ICollection<string>.Add(string item)
    {
      throw new NotSupportedException("Collection is read-only.");
    }
    void ICollection<string>.Clear()
    {
      throw new NotSupportedException("Collection is read-only.");
    }
    bool ICollection<string>.Remove(string item)
    {
      throw new NotSupportedException("Collection is read-only.");
    }
