	public class CustomerController : ControllerBase
	{ 
		 private ICustomerTypeRepository _customerTypeRepository;
		 private ICustomerRepository _customerRepository;
		 public CustomerController(ICustomerRepository customerRepository,
		 	ICustomerTypeRepository customerTypeRepository)
		 {
		 	_customerRepository = customerRepository;
			_customerTypeRepository = customerTypeRepository;
		 }
		 public ActionResult Index()
		 {
			 Customer customer 
                 = _customerRepository.GetCustomerWithId(customerId); 
                 // from where does customerId come?
			 IEnumerable<CustomerType> customerTypeList 
                 = _customerTypeRepository.GetTypes();
			. . .
		 }
	}
