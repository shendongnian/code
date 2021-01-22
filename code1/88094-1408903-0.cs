    public class CustomerRepository:IReadOnlyRepository<int, Customer>, IReadOnlyRepository<string, Customer>
    {
        public Customer Find(int customerId)
        {
        }
        public Customer Find(string customerName)
        {
        }
    }
