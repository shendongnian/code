    public partial class TestBase
    {
        protected readonly TestServer server;
        protected readonly IEFDatabaseContext DataContext;
        public TestBase()
        {
            this.server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            this.DataContext = this.server.Host.Services.GetService<IEFDatabaseContext>();
        }
        [OneTimeSetUp]
        public void TestInitialise()
        {
            this.DataContext.Database.EnsureCreated();
        }
        [OneTimeTearDown]
        public void TestTearDown()
        {
            this.DataContext.Database.EnsureDeleted();
        }
    }
