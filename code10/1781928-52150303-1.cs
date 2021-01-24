    public class HomeController : Controller
    {
        private readonly MssqlDbContext context;
        public HomeController(MssqlDbContext context)
        {
            this.context = context;
        }
        // class members here
    }
