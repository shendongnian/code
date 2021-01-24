    public class CustomerService
    {
         private readonly ICustomerFactory customerFactory;
         private readonly IConfiguration configuration;
    
         public CustomerService(ICustomerFactory customerFactory, IConfiguration configuration)
         {
              this.customerFactory = customerFactory;
              this.configuration = configuration;
         }
    
         public IEnumerable<CustomerModel> GetAllCustomers()
         {
             using(var customerContext = customerFactory.InstantiateCustomer(configuration))
                  return customerContext.RetrieveAllCustomers();
         }
    
         public CustomerModel GetCustomerOrders(CustomerModel customer)
         {
              using(var customerContext = customerFactory.InstantiateCustomer(configuration))
                  return customerContext.RetrieveCustomerWithOrders(customer.Id);
         }
    }
