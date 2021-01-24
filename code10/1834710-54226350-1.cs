    public class SomeController : Controller
    {
        private readonly NavigationContext _context;
        public SomeController(NagivationContext context)
        {
            _context = context;
        }
    }
