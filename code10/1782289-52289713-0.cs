    [Test]
    public async Task ShouldHaveOrderOfZero()
    {
        // Assemble
        const string categoryId = "cameras";
        var services = SortationContext.GivenServices();
        var sortationProvider = services.WhenGetSortationProvider();
        var sortations = new List<Sortation>();
        var sortation = new Sortation { CategoryId = categoryId };
        // the key moq configuration here
        services.MockSortationService.Setup(x => x.ListAsync(It.IsAny<string>())).Returns(Task.FromResult(sortations));
        // Act
        await sortationProvider.SaveAsync(sortation);
        // Assert
        sortation.Order.Should().Be(0);
    }
    public class SortationProvider
    {
        private SortationService _sortationService;
        public SortationProvider()
        {
            _sortationService = new SortationService();
        }
        public async Task<Sortation> SaveAsync(Sortation sortation)
        {
            if (sortation.Id == 0)
            {
                var sortations = await ListAsync(sortation.CategoryId);
                sortation.Order = sortations.Count;
                _sortationService.Create(sortation);
            }
            else
            {
                _sortationService.Update(sortation);
            }
            await _sortationService.SaveChangesAsync();
            return sortation;
        }
        // should be virtual
        public virtual async Task<List<Sortation>> ListAsync(string categoryId, params string[] includes) =>
            await _sortationService.List(includes).Where(m => m.CategoryId.Equals(categoryId)).ToListAsync();
    }
    public class SortationContext
    {
        public static Services GivenServices()
        {
            return new Services();
        }
    }
    public class Services
    {
        public Services()
        {
            MockSortationService = new Mock<SortationProvider>();
        }
        public SortationProvider WhenGetSortationProvider()
        {
            return MockSortationService.Object;
        }
        public Mock<SortationProvider> MockSortationService { get; set; }
    }
    internal class SortationService
    {
        public void Create(Sortation sortation)
        {
        }
        public void Update(Sortation sortation)
        {
        }
        public Task SaveChangesAsync()
        {
            return Task.CompletedTask;
        }
        public DbSet<Sortation> List(string[] includes)
        {
            throw new NotImplementedException();
        }
    }
    public class Sortation
    {
        public string CategoryId { get; set; }
        public int Id { get; set; }
        public int Order { get; set; }
    }
