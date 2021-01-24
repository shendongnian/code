    public class AllSportsStore : PageModel {
        private readonly DatastoreDb _db;
        public AllSportsStore() {
            _db = DatastoreDb.Create("projectid");
        }
        
        [BindProperty]
        public List<SportsStoreItem> SportsStoreList { get; set; }
        
        public IActionResult OnGet() {
            Query query = new Query("Sports_db");
            IEnumerable<Entity> stores = _db.RunQuery(query).Entities;
            SportsStoreList = stores.Select(_ => new SportsStoreItem {
                Name = (string)_["Name"],
                Price = (decimal)_["Price"]
            }).ToList();
            
            return Page();
        }
    }
    
