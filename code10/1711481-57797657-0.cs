	public class PersistentPropertiesSelectionRule<TEntity> : IMemberSelectionRule 
		where TEntity : class
	{
		public PersistentPropertiesSelectionRule(DbContext dbContext) => 
			this.dbContext = dbContext;
		public bool IncludesMembers => false;
		public IEnumerable<SelectedMemberInfo> SelectMembers(
			IEnumerable<SelectedMemberInfo> selectedMembers, 
			IMemberInfo context, 
			IEquivalencyAssertionOptions config)
		{
			var dbPropertyNames = dbContext.Model
				.FindEntityType(typeof(TEntity))
				.GetProperties()
				.Select(p => p.Name)
				.ToArray();
			return selectedMembers.Where(x => dbPropertyNames.Contains(x.Name));
		}
		public override string ToString() => "Include only persistent properties";
		readonly DbContext dbContext;
	}
