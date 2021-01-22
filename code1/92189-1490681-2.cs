    public interface IEntity
    {
         // Common to all Data Objects
    }
    
    public interface ICustomer : IEntity
    {
         // Specific data for a customer
    }
    
    
    public interface IRepository<T, TID> : IDisposable where T : IEntity
    {
         T Get(TID key);
         IList<T> GetAll();
         void Save (T entity);
         T Update (T entity);
         // Common data will be added here
    }
    
    public class Repository<T, TID> : IRepository<T, TID>
    {
         // Implementation of the generic repository
    }
    
    public interface ICustomerRepository
    {
         // Specific operations for the customers repository
    }
    
    public class CustomerRepository : Repository<ICustomer, int>, ICustomerRepository
    {
         // Implementation of the specific customers repository
    }
