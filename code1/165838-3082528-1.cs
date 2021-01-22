    public HomeController: Controller
    {
        private readonly IMapper<Customer, TestCustomerForm> _customerMapper;
        public HomeController(IMapper<Customer, TestCustomerForm> customerMapper)
        {
            _customerMapper = customerMapper;
        }
        public ActionResult Index()
        {
            TestCustomerForm cust = _customerMapper.Map(
                _repository.GetCustomerByLogin(CurrentUserLoginName)
            );
            return View(cust);
        }
    }
