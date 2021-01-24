     public class AddPeopleToCountryViewComponent:ViewComponent
    {
        private readonly MVCDbContext _context;
        public AddPeopleToCountryViewComponent(MVCDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync(
        int maxPriority, bool isDone)
        {
            ViewData["Customer"] = new SelectList(_context.Customer, "Id", "Name");
            ViewData["Country"] = new SelectList(_context.Country, "Id", "Id");
            return View();
        }
    }
