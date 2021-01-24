    public class MyContext : DbContext
    {
        public DbSet<Entity1> Entity1 { get; set; }
        public DbSet<Entity2> Entity2 { get; set; }
        
        // and so on ...
    }
