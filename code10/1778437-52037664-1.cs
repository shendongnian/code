      protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
           
            builder.Entity<TodoItem>()
                   .Property(t => t.Id)
                   .HasValueGenerator<IdValueGenerator>();
        }
