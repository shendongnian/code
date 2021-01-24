    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.EntitiesOfType<ISoftDeletable>(builder =>
        {
            builder.Property<bool>(nameof(ISoftDeletable.IsActive)).HasDefaultValue(true);
            // query filters :)
            var param = Expression.Parameter(builder.Metadata.ClrType, "p");
            var body = Expression.Equal(Expression.Property(param, nameof(ISoftDeletable.IsActive)), Expression.Constant(true));
            builder.HasQueryFilter(Expression.Lambda(body, param));
        });
    }
