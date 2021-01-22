    public class CustomerRepository : IRepository<Customer>
    {
        public List<Customer> Get(Func<Customer, bool> predicate)
        {
            using (var context = new ErpEntities())
            {
                 return context.Customers.Where(predicate).ToList();
            }
        }
    }
