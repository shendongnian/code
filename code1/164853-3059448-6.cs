    class Repository<T> where T:class
    {  
      public IQueryable<T> SearchExact<U>(string keyword) where U: T,IName
      {  
        return db.GetTable<U>().Where(i => i.Name == keyword);
      }
    }  
