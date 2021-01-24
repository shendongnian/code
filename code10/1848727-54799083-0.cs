modelBuilder.Entity<T>
            .ChainIndex(h => h.Column1)
            .ChainIndex(h => h.Column2);
public static EntityTypeBuilder<TEntity> ChainIndex<TEntity>(this EntityTypeBuilder<TEntity> builder, Expression<Func<TEntity, object>> indexExpression) where TEntity : class
{
    builder.HasIndex(indexExpression);
    return builder;
}
Or
builder.Entity<T>()
    .AddIndex(indexBuilder => indexBuilder.HasIndex(h => h.Column1))
    .AddIndex(indexBuilder => indexBuilder.HasIndex(h => h.Column2).IsUnique());
public static EntityTypeBuilder<TEntity> AddIndex<TEntity>(this EntityTypeBuilder<TEntity> builder, Action<EntityTypeBuilder<TEntity>> action) where TEntity : class
{
    action(builder);
    return builder;
}
