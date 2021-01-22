    namespace WebApplicationProject.Controllers
    {
        public class CustomersController : Controller
        {
            private IRepository<Customer> _customerRepository;
    
            public CustomersController() { }
    
            public CustomersController(IRepository<Customer> customerRepository)
            {
                this._customerRepository = customerRepository;
            }
    
            public ViewResult List(string customerType, int page)
            {
                var customerByType = (entryType == null) ?
                    customerRepository.Items : customerRepository.Items.Where(x => x.CustomerType == customerType);
    
                int totalCustomers = customerByType.Count();
                ViewData["TotalPages"] = (int)Math.Ceiling((double)totalCustomers/ PageSize);
                ViewData["CurrentPage"] = page;
                ViewData["CustomerType"] = customerType;
    
                return View(customerByType
                    .Skip((page - 1) * PageSize)
                    .Take(PageSize)
                    .ToList()
                );
            }
    
        }
    }
