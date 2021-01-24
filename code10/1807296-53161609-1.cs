    public class CarQuoteOptionsService
    {
        private readonly ModelsContext _context;
        public CarQuoteOptionsService(ModelsContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public Task<List<SelectListItem>> GetBrandOptionsAsync =>
            _context.Brands.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name
            }).ToListAsync();
        // etc
    }
