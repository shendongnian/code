     public CustomerService : ICustomerService {
          private readonly ICustomerRepository _repository;
          public CustomerService(ICustomerRepository repository) {
               _repository = repository;
          } 
          public void MakeCustomerPreferred(Customer preferred) {
               MakePreferred(customer);
               _repository.Save(customer);
          }
          protected virtual void MakePreferred(Customer customer) {
              // Or more than likely some grungy logic
              customer.IsPreferred = true;
          }
     }
