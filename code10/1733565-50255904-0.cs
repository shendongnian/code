    [Collection("Integration test collection")]
    public class BookServiceTest : IDisposible
    {
        private BDPContext _context;
        public BookServiceTest()
        {
            DbContextOptions<BPDContext> options = new DbContextOptionsBuilder<BPDContext>()
                .UseInMemoryDatabase(GetType().Name)
                .Options;
            _context = new BPDContext(options);
        }
        [Fact]
        public void CanCreateUser()
        {
            var Book = new BookService(context);
            Data.Database.Entities.Book book = Book.AddNewBook("test");
            context.SaveChanges();
            book.Id.Should().NotBe(0);
            book.Name.Should().Be("test");
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
  
