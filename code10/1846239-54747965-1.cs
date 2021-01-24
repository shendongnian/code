    class MyDbContext : DbContext
    {
         public DbSet<TestTag> TestTags {get; set;}
         public DbSet<TestParent> TestParents {get; set;}
         public DbSet<TestChild> TestChildren {get; set;}
    }
