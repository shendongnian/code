    public class MenuViewComponent : ViewComponent
    {
        private readonly YourDbContext _context;
        public MenuViewComponent(YourDbContext context)
        {
            _context= context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = await db.Pages.ToListAsync();
            return View(items);
        }        
    }
