    public class AllSportsStore : PageModel {
        private readonly DatastoreDb _db;
        public AllSportsStore() {
            _db = DatastoreDb.Create("projectid");
        }
        
        [BindProperty]
        public SportsStoreItem SportsStore { get; set; }
        [BindProperty]
        public List<SportsStoreItem> SportsStoreList { get; set; }
        
        public IActionResult OnGet() {
            Query query = new Query("StoreList")
            {
                Order = { { "Name", PropertyOrder.Types.Direction.Descending } }
            };
            IEnumerable<Entity> stores = _db.RunQuery(query).Entities;
            SportsStoreList = stores.Select(_ => new SportsStoreItem {
                Name = _["Name"],
                Price = _["Price"]
            }).ToList();
            
            return Page();
        }
    }
    
