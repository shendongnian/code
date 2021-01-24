    public class CustomerRepository : EFRepository<Customer, Guid>, ICustomerRepository
    {
        public CustomerRepository(IDbContext context): base(context) {}
        public async Task<List<Customer>> GetCustomerBySearchTerms(string[] searchTerms)
        {
           //implement your logic here
        }
    }
