    class MyQueryable<T> : IQueryable<T>
    {
         public type ElementType {get; set;}
         public Expression Expression {get; set;}
         public Provider Provider {get; set;}
    } 
    IQueryable<T> queryOnDbContextA= dbCotextA ...
    IQueryable<T> setInDbContextB = dbContextB.Set<T>();
    IQueryable<T> queryOnDbContextB = new MyQueryable<T>()
    {
         ElementType = queryOnDbContextA.ElementType,
         Expression = queryOnDbContextB.Expression,
         Provider = setInDbContextB.Provider,
    }
