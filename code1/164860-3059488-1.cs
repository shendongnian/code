    class Repository<T>
    {  
      public IQueryable<T> SearchExact(string keyword, Func<T, string> getSearchField)  
      {  
        return db.GetTable<T>().Where(i => getSearchField(i) == keyword);
      }
    }
