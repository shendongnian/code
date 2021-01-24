        public class SomeTests : IDisposable
    {
            public SomeTests()
            {
                var options = new DbContextOptionsBuilder<MyContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString())
                    .Options;
    
                _dbContext = new MyContext(options);
                _dbContext.Database.EnsureDeleted();
                _dbContext.Database.EnsureCreated();
    
                // you can provide some more settings here
            }
    
            public void Dispose()
            {
                _dbContext?.Dispose();
            }
    }
