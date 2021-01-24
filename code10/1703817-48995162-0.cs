    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
    
        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }
    
        public async Task<IActionResult> Index()
        {
            PartialLoginViewModel model = new PartialLoginViewModel();
            var userName = User.Identity.Name;
            var applicationUser = await _context.ApplicationUser.SingleOrDefaultAsync(m => m.UserName == userName);
    
            model.Nome = applicationUser.Nome;
            ViewData["userModel"] = model;
    
            return View();
        }
