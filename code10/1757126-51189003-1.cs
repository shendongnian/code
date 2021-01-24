    public class IndexModel : PageModel {
        private readonly AppDbContext _db;
    
        public IndexModel(AppDbContext db) {
            _db = db;
        }
    
        public IList<Customer> Customers { get; private set; }
    
        public async Task<IActionResult> OnGetAsync() {
            Customers = await _db.Customers.AsNoTracking().ToListAsync();
            return Page();
        }
    
        public async Task<IActionResult> OnPostAsync(int id) {
            var contact = await _db.Customers.FindAsync(id);
    
            if (contact != null) {
                _db.Customers.Remove(contact);
                await _db.SaveChangesAsync();
            }    
            return RedirectToPage("/Index");
        }   
    }
