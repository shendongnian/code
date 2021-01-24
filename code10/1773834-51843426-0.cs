    public class MyController : Controller
    {
        private readonly myContext _context;
        public MyController(myContext context)
        {
            _context = context;
        }
    }
