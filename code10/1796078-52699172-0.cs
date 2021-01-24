    protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new 'className+Config'());
            base.OnModelCreating(modelBuilder);
        }
