    public class DatabaseFixture : IDisposable
    {
        public ApplicationDbContext _context;
        public DbContextOptions<ApplicationDbContext> _options;
        public IUoW _uow;
        public DatabaseFixture()
        {
            var x = Directory.GetCurrentDirectory();
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.Tests.json", optional : true)
                .Build();
            _options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "ProviderTests")
                .Options;
            _context = new ApplicationDbContext(_options);
            _context.Database.EnsureCreated();
            Initialize();
            _uow = new UoW(_context);
        }
        private void Initialize()
        {
            _context.Accounts.Add(new Entities.Account() { AccountNumber = "Number 1", AccountID = "", AccountUniqueID = "" });
            _context.Accounts.Add(new Entities.Account() { AccountNumber = "Number 2", AccountID = "", AccountUniqueID = "" });
            _context.Accounts.Add(new Entities.Account() { AccountNumber = "Number 3", AccountID = "", AccountUniqueID = "" });
            _context.Accounts.Add(new Entities.Account() { AccountNumber = "Number 4", AccountID = "", AccountUniqueID = "" });
            _context.SaveChanges();
        }
        public void Dispose()
        {
            // Clean Up
            _context.Database.EnsureDeleted();
        }
    }
    [CollectionDefinition("Database Collection")]
    public class DatabaseCollection : ICollectionFixture<DatabaseFixture>
    {
    }
