    public class RedirectController
    {
        private readonly ApplicationDbContext dbContext;
        public RedirectController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext
                ?? throw new ArgumentNullException(nameof(dbContext));
        }
        public IActionResult GoToFull(int id)
        {
            var link = dbContext.Links.FirstOrDefault(x => x.Id == id);
            return new RedirectResult(link.FullLink);
        }
    }
