    public class MyDbContextWithMissingColumns: MyDbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Foo>().Ignore(f => f.SomeProperty);
            base.OnModelCreating(modelBuilder);
        }
    }
