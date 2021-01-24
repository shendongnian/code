	public static class FluentAssertionExtensions
	{
		public static EquivalencyAssertionOptions<TEntity> IncludingPersistentProperties<TEntity>(this EquivalencyAssertionOptions<TEntity> options, DbContext dbContext) 
			where TEntity : class
		{
			return options.Using(new PersistentPropertiesSelectionRule<TEntity>(dbContext));
		}
	}
