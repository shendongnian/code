    public class CustomerController {
        private readonly ICustomerService _customerService;
    
        [InjectionConstructor]
        public CustomerController(ICustomerService customerService) {
            _customerService = customerService;
        }
    
        public void Operation() {
            Console.WriteLine(_customerService.Operation());
        }
    }
