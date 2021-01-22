    class Repository<T> where T:class
    {  
      public IQueryable<T> SearchExact<U>(string keyword) where U: T,IName
      {
        var prop = typeof(T).GetProperty("Name");
        return db.GetTable<U>().Where(i => (string)prop.GetValue(i) == keyword);
      }
    }
