    public class SomeController : Controller
    {
        private readonly CustomerService customerService;
        public SomeController(CustomerService customerService)
        {
            this.customerService = customerService;
        }
        public IActionResult Index() 
        {
            return Json(customerService.GetCustomer());
        }
    }
