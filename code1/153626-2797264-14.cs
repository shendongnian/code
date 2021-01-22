    namespace WebApplicationProject.Controllers
    {
        public class CustomersController : Controller
        {
            private IRepository<Customer> _customerRepository;
            public int PageSize { get; set; }
    
            public CustomersController() { }
    
            public CustomersController(IRepository<Customer> customerRepository)
            {
                this._customerRepository = customerRepository;
                // let's set it to 10 items per page.
                this.PageSize = 10; 
            }
    
            public ViewResult List(string customerType, int page)
            {
                var customerByType = (customerType == null) ?
                    customerRepository.Items : customerRepository.Items.Where(x => x.CustomerType == customerType);
    
                int totalCustomers = customerByType.Count();
                ViewData["TotalPages"] = (int)Math.Ceiling((double)totalCustomers/ PageSize);
                ViewData["CurrentPage"] = page;
                ViewData["CustomerType"] = customerType;
 
                // get the right customers from the collection
                // based on page number and customer type.    
                return View(customerByType
                    .Skip((page - 1) * PageSize)
                    .Take(PageSize)
                    .ToList()
                );
            }
    
        }
    }
