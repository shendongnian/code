    public class RepositoryFactory
    {
        public IRepository CreateCustomerContactRepository(FoodieTenantContext context) => 
            return new CustomerContactRepository(context);
    }
