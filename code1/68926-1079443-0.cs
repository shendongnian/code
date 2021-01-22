    public interface ICustomerRepository
    {
        Customer GetCustomer(int id);
    }
    public class NhibCustomerRepository : ICustomerRepository
    {
        public Customer GetCustomer(int id)
        {
            // NHibernate implementation
        }
    }
    public class LtsCustomerRepository : ICustomerRepository
    {
        public Customer GetCustomer(int id)
        {
            // Linq2Sql implementation
        }
    }
