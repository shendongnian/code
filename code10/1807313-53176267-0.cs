    // Repositories:
    public interface ICustomerRepository : IDisposable
    {
         IEnumerable<CustomerModel> RetrieveAllCustomers();
    
         CustomerModel RetrieveCustomerWithOrders(int id);
    }
    
    // Context:
    public class CustomerContext : ICustomerRepository
    {
         private bool disposed = false;
         private readonly IDbConnection dbConnection;
    
         public CustomerContext(IConfiguration configuration) => dbConnection = configuration.GetConnectionString("dbConnection");
    
         public IEnumerable<CustomerModel> RetrieveAllCustomers() => dbConnection.Query<CustomerModel>(query);
    
         public CustomerModel RetrieveCustomerWithOrders(int id) => dbConnection.Query<CustomerModel, OrderModel, CustomerModel>(query, (customer, order) =>
         {
              customer.Orders = order;
              return customer;
         }, new { CustomerId = id });
    
         public virtual bool Dispose(bool disposing)
         {
             if(!disposed)
             {
                  if(disposing)
                      dbConnection.Dispose();
    
                  disposed = true;
             }
         }
    
         public void Dispose() 
         {
              Dispose(true);
              GC.SuppressFinalize(this);
         }
    
         ~CustomerContext() => Dispose(true);     
    }
    
    // Factory:
    public class CustomerFactory : ICustomerFactory
    {
         private readonly IConfiguration configuration;
    
         public CustomerFactory(IConfiguration configuration) => this.configuration = configuration;
    
         public ICustomerRepository InstantiateCustomer() => new CustomerContext(configuration);
    }
    
    public interface ICustomerFactory
    {
         ICustomerRepository InstantiateCustomer();
    }
