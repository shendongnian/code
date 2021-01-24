    public class ApplicationDbContext : DbContext
    {
      public ApplicationDbContext() : base("name=Northwind")
      {
          
      }
    }
