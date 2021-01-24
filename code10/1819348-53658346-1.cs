    class MyHierarchyConfiguration
    {
        public void Apply(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MyBaseEntity>(builder =>
            {
                // base entity configuration here
            });
            modelBuilder.Entity<MyDerivedEntity1>(builder =>
            {
                // derived entity configuration here
            });
            modelBuilder.Entity<MyDerivedEntity2>(builder =>
            {
                // derived entity configuration here
            });
            // etc.
        }
    }
