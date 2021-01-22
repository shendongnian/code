    [TestClass]
    public static class SampleAssemblySetup
    {
        private const string ConnectionString = "FullUri=file:memorydb.db?mode=memory&cache=shared";
        private static SQLiteConnection _connection;
        [AssemblyInitialize]
        public static void AssemblyInit(TestContext context)
        {
            var configuration = Fluently.Configure()
                                           .Database(SQLiteConfiguration.Standard.ConnectionString(ConnectionString))
                                           .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.Load("MyMappingsAssembly")))
                                           .ExposeConfiguration(x => x.SetProperty("current_session_context_class", "call"))
                                           .BuildConfiguration();
            // Create the schema in the database
            // Because it's an in-memory database, we hold this connection open until all the tests are finished
            var schemaExport = new SchemaExport(configuration);
            _connection = new SQLiteConnection(ConnectionString);
            _connection.Open();
            schemaExport.Execute(false, true, false, _connection, null);
        }
        [AssemblyCleanup]
        public static void AssemblyTearDown()
        {
            if (_connection != null)
            {
                _connection.Dispose();
                _connection = null;
            }
        }
    }
