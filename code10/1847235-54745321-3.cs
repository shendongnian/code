    interface IDbContextFactory<TContext>
       where TContext : DbContext
    {
        DbContext Create();
    }
    // The MyDbContextFactory is a factory that upon request will create one MyDbcontext object
    // passing the JwtHelper in the constructor of MyDbContext
    class MyDbContextFactory : IDbContextFactory<MyDbContext>
    {
          public IJwthHelper JwtHelper {get; set;}
          public MyDbContext Create()
          {
               return new MyDbContext(this.JwtHelper);
          }
    }
