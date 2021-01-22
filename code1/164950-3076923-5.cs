    public class HomeController : Controller
    {
        private readonly IUsersRepository _repository;
        public HomeController(IUsersRepository repository)
        {
            _repository = repository;
        }
        public ActionResult Index()
        {
            return View(_repository.GetUsers());
        }
    }
