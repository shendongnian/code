    public class CreateModel : PageModel
    {
        private readonly AppDbContext _db;
    
        public CreateModel(AppDbContext db)
        {
            _db = db;
        }
    }
