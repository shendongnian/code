        public class ApplicationUserStore : IApplicationUserStore
        {
             private ApplicationDbContext _context;
             private readonly UserManager<ApplicationUser> _userManager;
             public ApplicationUserStore(ApplicationDbContext ctx, 
             UserManager<ApplicationUser> userManager)
             {
                _context = ctx;
                _userManager = userManager;
             }
             public async Task<ApplicationUser> Get(string email)
             {
                 return await _context.Users.Where(u => u.Email == 
                 email).SingleOrDefaultAsync();
             }
              public async Task<IdentityResult> Create(ApplicationUser user, 
              string password)
              {
                   return await _userManager.CreateAsync(user, password);
              }
        }
