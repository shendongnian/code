         public readonly Infomaster _dbContext;
       
         public Repository(Infomaster dbContext)
          {
                _dbContext = dbContext;
           }
   
         public void Add(T entity)
         {
             _dbContext.Set<T>.Add(t);
         }
    }
