    public class SomeController : ControllerBase
    {
        private readonly UniversityDbContext _context;
        public SomeController(UniversityDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task Post([FromBody] string value)
        {
            ...
            await _context.SaveChangesAsync();
        }
    }
