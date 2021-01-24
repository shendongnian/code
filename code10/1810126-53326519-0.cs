    static void Configure<TEntity, T>(ModelBuilder modelBuilder)
    	where TEntity : BaseEntity<T>
    {
    	modelBuilder.Entity<TEntity>(builder =>
    	{
    		builder.Property(e => e.OrderId).ValueGeneratedOnAdd();
    	});
    }
