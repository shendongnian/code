     public IQueryable<T> MyQuery(DbContext<T> db)
     {
         return db.Table
                  .Where(p => p.reallycomplex)
                  ....
                  ...
                  .OrderBy(p => p.manythings);
     }
