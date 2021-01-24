    public class CustomerController : Controller
    {
        private readonly CustomerService customerService;
        public CustomerController(CustomerService customerService)
        {
            this.customerService = customerService;
        }
        public IActionResult Index() 
        {
            return Json(customerService.GetCustomer());
        }
    }
