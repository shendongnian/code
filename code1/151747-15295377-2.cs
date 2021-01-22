	static void Main(string[] args)
	{
		string connectionString = @"server=.\SQLEXPRESS;database=testdb;uid=sa2;pwd=Passw0rd";
		Announcer announcer = new TextWriterAnnouncer(s => System.Diagnostics.Debug.WriteLine(s));
		announcer.ShowSql = true;
		
		Assembly assembly = Assembly.GetExecutingAssembly();
		IRunnerContext migrationContext = new RunnerContext(announcer);
		var options = new ProcessorOptions 
		{ 
			PreviewOnly = false,  // set to true to see the SQL
			Timeout = 60 
		};
		var factory = new SqlServer2008ProcessorFactory();
		using (IMigrationProcessor processor = factory.Create(connectionString, announcer, options))
        {
            var runner = new MigrationRunner(assembly, migrationContext, processor);
            runner.MigrateUp(true);
		
            // Or go back down
            //runner.MigrateDown(0);
        }
    }
	[Migration(1)]
	public class CreateUserTable : Migration
	{
		public override void Up()
		{
			Create.Table("person")
				.WithColumn("Id").AsGuid().PrimaryKey()
				.WithColumn("Name").AsString();
		}
		public override void Down()
		{
			Delete.Table("person");
		}
	}
