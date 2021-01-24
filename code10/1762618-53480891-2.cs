    [TestFixture]
    class QueryControllerTests
    {
        private IOptions<MongoSettings> _mongoSettings;
        private QueryController _queryController;
        private Mock<IFakeMongoCollection > _fakeMongoCollection;
        private Mock<IMongoDatabase> _fakeMongoDatabase;
        private Mock<IMongoContext> _fakeMongoContext;
        private Mock<IFindFluent<BsonDocument, BsonDocument>> _fakeCollectionResult;
        [OneTimeSetUp]
        public void Setup()
        {
            _fakeMongoCollection = new Mock<IFakeMongoCollection >();
            _fakeCollectionResult = new Mock<IFindFluent<BsonDocument, BsonDocument>>(
            _fakeMongoDatabase = new Mock<IMongoDatabase>();
            _fakeMongoDatabase
                .Setup(_ => _.GetCollection<BsonDocument>("Test", It.IsAny<MongoCollectionSettings>()))
                .Returns(_fakeMongoCollection.Object);
            _fakeMongoContext = new Mock<IMongoContext>();
            _fakeMongoContext.Setup(_ => _.GetConnection()).Returns(_fakeMongoDatabase.Object);        
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false)
                .Build();
            _mongoSettings = Options.Create(configuration.GetSection("MongoConnection").Get<MongoSettings>());
            _queryController = new QueryController(_mongoSettings, _fakeMongoContext.Object);
        }
    }
