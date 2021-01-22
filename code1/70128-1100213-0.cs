    @WebService
    @Stateless
    class BusinessProcess implements IBusinessProcess
    {
       @EJB ICustomerRepository customerRepository;
       public Customer getTheBestCustomer()
       {
          return customerRepository.findTheBestCustomer();
       }
       // or just simple method without hidden logic
       public HelloWorldObject helloWorld()
       {
          return new HelloWorldObject("Earth");
       }
    }
