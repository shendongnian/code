    public IEnumerable<T> Results
    {
      get
      {
        using(IDataReader rdr = GetReader())
          while(rdr.Read())
            yield return Build(rdr);
      }
    }
