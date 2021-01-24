    public class CustomerController {
        private readonly ICustomerRepository customerRepository;
    
        public CustomerController(ICustomerRepository CustomerRepository)
        {
            customerRepository = CustomerRepository;
        }
        // GET: Customers
        public ActionResult Index()
        {
            var customers = customerRepository.GetAll()
    
        
            return View(customers);
        }
    }
