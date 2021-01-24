    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.EntitiesOfType<ISoftDeletable>(builder =>
        {
            builder.Property<bool>(nameof(ISoftDeletable.IsActive)).HasDefaultValue(true);
            // query filters :)
            var param = Expression.Parameter(builder.Metadata.ClrType, "p");
            var body = Expression.IsTrue(Expression.Property(param, nameof(ISoftDeletable.IsActive)));
            builder.HasQueryFilter(Expression.Lambda(body, param));
        });
    }
