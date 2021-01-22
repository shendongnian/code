    public class CustomerService 
    {
        private readonly ICustomerRepository _customerRepository;
    
        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
       
        public Customer GetCustomerById(int id)
        {
            var cached = _customerRepository.FindByPK(id);
            if(cached != null) return cached;
    
            var webserviceData = Webservice.GetData(id);  // You could inject the web service as well...
            var customer = ConvertDataToCustomer(webserviceData);
    
            _customerRepository.SaveCustomer(customer);
    
            return customer;
        }
    }
