    public class Repository : IRepository
    {
        public async Task<List<Product>> GetProductsAsync()
        {
            return await _dbContext.Products.ToListAsync();
        }
    }
    public class Service : IService
    {
        private readonly IRepository _repository;
        public Service(IRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<Product>> GetProductsFromDbAsync()
        {
            return await _repository.GetProductsAsync();
        }
    }
