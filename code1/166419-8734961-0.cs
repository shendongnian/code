    public abstract class GenericRepositoryController<TModel> : Controller
    {
        private readonly IRepository<TModel> _repository;
        protected GenericRepositoryController(IRepository<TModel> repository)
        {
            _repository = repository;
        }
        public ActionResult Index()
        {
            var model = _repository.GetAll();
            return View(model);
        }
    }
    public class EmployeeController : GenericRepositoryController<Employee>
    {
        public EmployeeController(IRepository<Employee> repository) : base(repository)
        {
        }
    }
    public class CustomerController : GenericRepositoryController<Customer>
    {
        public CustomerController(IRepository<Customer> repository) : base(repository)
        {
        }
    }
     
