    public class Repository : IRepository
    {
        public List<Product> GetProducts()
        {
            return _dbContext.Products.ToList();
        }
    }
    
    public class Service : IService
    {
        private readonly IRepository _repository;
    
        public Service(IRepository repository)
        {
            _repository = repository;
        }
    
        public List<Product> GetProductsFromDb()
        {
            return _repository.GetProducts();
        }
    }
