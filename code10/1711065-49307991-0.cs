    public class HomeController : Controller
    {
        private readonly IRepository<ApplicationUser> _userRepository;
    
        public HomeController(IRepositoryFactory repositoryFactory)
        {
            _userRepository = repositoryFactory.GetRepository<ApplicationUser>(); // ERROR: No service for type 'UserRepository' has been registered
        }
    
        // [...]
    }
