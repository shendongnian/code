    public class Product {
      public int Id {get; set;}
      public int CustomerId { get; set;}
      public virtual Customer Customer { get; set;}
    }
    public class ProductLazyLoadProxy {
      ICustomerRepository _customerRepository;
      public ProductLazyLoadProxy(ICustomerRepository customerRepository) {
        _customerRepository = customerRepository;
      }
      public override Customer {
        get {
          if(base.Customer == null)
            Customer = _customerRepository.Get(CustomerId);
          return base.Customer
        }
        set { base.Customer = value; }
      }
    }
    public class ProductRepository : IProductRepository {
      public Product Get(int id) {
        var dr = GetDataReaderForId(id);
        return new ProductLazyLoadProxy() {
          Id = Convert.ToInt(dr["id"]),
          CustomerId = Convert.ToInt(dr["customer_id"]),
        }
      }
    }
