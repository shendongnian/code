    public class SomeController : ControllerBase
    {
        private readonly UniversityDbContext _context;
        public SomeController(UniversityDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public void Post([FromBody] string value)
        {
            ...
            _context.SaveChangesAsync();
        }
    }
