    public Interface IRepository<T>{
      List<T> GetAll();
      void Create(T p);
      void Update(T p);
    }
    public interface IProductRepository {
      //Extension methods if needed
       List<Product> GetProductsByCustomerID();
       List<T> GetAll();
       void Create(T p);
       //Let assume here you should not be able to update the products
    }
    public ProductRepository : IProductRepository {
        private IRepository _repository;
        public ProductRepository(IRepository repository) {
            this._repository = repository;
        }
           List<T> GetAll() 
           {
                _repository.GetAll();
           }
           void Create(T p) 
           {
                _repository.Create(p);
           }
           List<Product> GetProductsByCustomerID() 
           {
              //..implementation goes here
           }
    }
