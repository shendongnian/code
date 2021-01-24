    public class MyQueryDbContext : DbContext
    {
      public virtual DbSet<MyResponse> Data { get; set; }
        .
        .
        .
    }
