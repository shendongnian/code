    public class TestClass
    {
        private DbContext _context;
        [SetUp]
        public void SetUp()
        {
            var options = 
                new DbContextOptionsBuilder<ElectronicsContext>()
                    .UseInMemoryDatabase(databaseName: "Products Test")
                    .Options;
            _context = new ElectronicsContext(options);
            // Use _context to insert initial data required for the test
        }
        [TearDown]
        public void TearDown()
        {
            _context.Dispose();
        }
        [Test]
        public void RunTest()
        {
            // run test
            // assert
            _context.Products.Count().Should().Be(10)
        }
    }
