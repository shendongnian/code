    public IQueryProvider Provider
    {
      get {
        return new Linq.CslaQueryProvider<T, C>(this);
      }
    }
