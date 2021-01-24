    public class ContactController : CookieController 
    {
        public ContactController(IHttpContextAccessor httpContextAccessor, MyDbContext dbContext) : base(httpContextAccessor,  dbContext)
        {
             await InitAes();
        }
        private async void InitAes()
        {
            await FindOrCreateAesConnexion(); 
        }
    }
