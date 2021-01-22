    abstract class ProviderBase<T>
    {
      public IEnumerable<T> Results
      {
        get
        {
          List<T> list = new List<T>();
          using(IDataReader rdr = GetReader())
            while(rdr.Read())
              list.Add(Build(rdr));
          return list;
        }
      }
      protected abstract IDataReader GetReader();
      protected T Build(IDataReader rdr);
    }
