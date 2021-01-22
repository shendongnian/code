    public CopyTo(T[] array, int arrayIndex)
    {
      try
      {
        _innerList.CopyTo(array, arrayIndex);
      }
      catch(ArgumentException ae)
      {
        throw ae;
      }
    }
