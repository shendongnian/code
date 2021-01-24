    public class HomeController : Controller
    {
        private readonly DataContext _context;
        private readonly IRepository _repo;
        public HomeController(DataContext context, IRepository repo)
        {
            this._context = context;
            this._repo = repo;
        }
        public int GetUserId()
        {
           return (int)HttpContext.Session.GetInt32("ID");
        }
