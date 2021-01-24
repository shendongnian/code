    public class CustomerTableViewComponent : ViewComponent
    {
        private readonly ProjectNameEntities _context;
        public CustomerTableViewComponent(ProjectNameEntities context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var customers = await _context.Customer.ToListAsync();
            return View(customers);
        }
    }
