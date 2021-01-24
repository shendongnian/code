        public class AuthorsListViewComponent : ViewComponent
        {
          private readonly ApplicationDbContext _appDbContext;
        public AuthorsListViewComponent(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var authorsList = await GetItemsAsync();
            return View(authorsList);
        }
        private Task<List<Author>> GetItemsAsync()
        {
            return _appDbContext.Authors.ToListAsync();
        }
    }
