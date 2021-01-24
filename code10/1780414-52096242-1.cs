    public class IndexModel : PageModel {
        private readonly AppDbContext _context;
    
        public IndexModel(AppDbContext db) {
            _context = db;
        }
    
        [BindProperty] // Adding this attribute to opt in to model binding. 
        public IList<TournamentStat> TournamentStats { get; set; }
     
        public async Task<IActionResult> OnGetAsync() { 
            var tournamentStats = await _context.TournamentBatchItem
                 .Where(t => t.Location == "Outdoor" || t.Location == "Indoor")
                 .GroupBy(t => t.Location)
                 .Select(t => new TournamentStat { Name = $"{ t.Key } Tournaments", Value = t.Count() })
                 .ToListAsync();
    
            tournamentStats.Add(new TournamentStat { 
                Name = "Total Tournaments", 
                Value = tournamentStats.Sum(t => t.Value) 
            });
    
            TournamentStats = tournamentStats; //setting property here
    
            return Page();
        }
    
        //...
    }
