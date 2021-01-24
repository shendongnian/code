    public class AllSportsStoreModel : PageModel {
    
        private readonly ISportsStore stores;
    
        public AllSportsStoreModel(ISportsStore stores) {
            this.stores = stores;
        }
    
        [BindProperty]
        public List<SportsStoreItem> SportsStoreList { get; set; }
    
        public IActionResult OnGet() {
            SportsStoreList = stores.ReadAll();
            return Page();
        }
    }
