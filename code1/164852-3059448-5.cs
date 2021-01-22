    class Repository<T> where T:class, IName
    {
      public IQueryable<T> SearchExact(string keyword)  
      {  
        return db.GetTable<T>().Where(i => i.Name == keyword);
      }
    }  
