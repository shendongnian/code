    public class CustomerRepository : EFRepository<Customer, Guid>, ICustomerRepository
    {
        public async Task<List<Customer>> GetCustomerBySearchTerms(string[] searchTerms)
        {
           //implement your logic here
        }
    }
