    /// <summary>
    ///     Creates a <see cref="DbSet{TEntity}" /> that can be used to query and save instances of <typeparamref name="TEntity" />.
    /// </summary>
    /// <typeparam name="TEntity"> The type of entity for which a set should be returned. </typeparam>
    /// <returns> A set for the given entity type. </returns>
    public virtual DbSet<TEntity> Set<TEntity>()
        where TEntity : class
        => (DbSet<TEntity>)((IDbSetCache)this).GetOrAddSet(DbContextDependencies.SetSource, typeof(TEntity));
