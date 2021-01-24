    public class ApplicationUsersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
    
        public ApplicationUsersController(ApplicationDbContext context,
                                          UserManager<IdentityUser> userManager;)
        {
            _context = context;
            _userManager = userManager;
        }
    
        // GET: Administrator/ApplicationUsers
        public async Task<IActionResult> Index()
        {
            return View(await _userManager.Users.ToListAsync());
        }
    }
