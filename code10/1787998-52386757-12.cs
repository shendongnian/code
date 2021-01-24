	public class MyContext
	{
		private readonly DatabaseOptions databaseOptions;
		
		public MyContext(DbContextOptions<MyContext> options, IOptions<DatabaseOptions> databaseOptions)
			: base(options)
		{
			this.databaseOptions = databaseOptions.Value;
		}
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			//here I need my connection string
			optionsBuilder.UseMySql(databaseOptions.ConnectionString);
		}
	}
