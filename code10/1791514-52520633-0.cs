    public interface ICustomerRepository : IDisposable
    {
         IEnumerable<Customer> RetrieveAll();
    }
    
    public interface ICustomerFactory
    {
         ICustomerRepository Create();
    }
    
    public class CustomerFactory : ICustomerFactory
    {
         public ICustomerRepository Create() => new CustomerContext();
    }
    
    public class CustomerContext : ICustomerRepository
    {
         public CustomerContext()
         {
              // Instantiate your connection manager here.
         }
    
         public IEnumerable<Customer> RetrieveAll() => dbConnection.Query<Customer>(...);
    }
