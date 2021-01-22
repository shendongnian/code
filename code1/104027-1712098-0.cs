    public void bind<T>(IEnumerable<T> list)
    {
      foreach (T item in list)
      {
       process(item);
      }
    }
