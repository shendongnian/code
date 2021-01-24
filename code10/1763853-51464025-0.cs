    public abstract class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(FoodieTenantContext context)
        {
            this.Context = context;
        }
    
        // ... rest of the class
    }
    
    // usage could be like the following
    
    public class CustomerUOW : UnitOfWork
    {
        public CustomerService(Func<FoodieTenantContext, IRepository<CustomerRepository>> customerRepo
            , Func<FoodieTenantContext, IRepository<CustomerContactRepository>> contactRepo
            , FoodieTenantContext context) 
            : (context)
        {        
            _customerRepo = customerRepo(context);
            _contactRepo = contactRepo(context);
        }
    }
