    class Repository<T> where T:class
    {
      static PropertyInfo _nameProperty = typeof(T).GetProperty("Name");
      public IQueryable<T> SearchExact(string keyword)
      {
        return db.GetTable<T>().Where(i => (string)_nameProperty.GetValue(i) == keyword);
      }
    }
