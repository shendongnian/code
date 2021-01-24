    public class MyDbContextWithMissingColumns: MyDbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            if (myConfig.UseDatabaseWithoutSomeProperties)
            {
              modelBuilder.Entity<Foo>().Ignore(f => f.SomeProperty);
            }
            base.OnModelCreating(modelBuilder);
        }
    }
