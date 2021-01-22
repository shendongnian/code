    public class FooBarQuery
    {
      public Bar Criteria { get; set; }
    
      public IQueryable[Foo] GetQuery( IQueryable[Blah] queryable )
      {
         return from foo in queryable.Foos
            where foo.Bar == Criteria
            select foo;
      } 
    }
