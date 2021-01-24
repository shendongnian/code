    namespace identityDemo.Controllers
    {
        public class UserManagementController : Controller
        {
            private readonly ApplicationDbContext _context;
            private readonly RoleManager<IdentityRole> _roleManager;
            private readonly UserManager<IdentityUser> _userManager;
    
                public UserManagementController(ApplicationDbContext context, 
    UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
            {
                _context = context;
                _roleManager = roleManager; 
                _userManager = userManager; 
            }
    
            // GET: ApplicationUserRoles
            public async Task<IActionResult> GetApplicationUsersAndRoles()
            {
                return View(new UserMv(
                    (from user in await _userManager.Users.ToListAsync()
                     select new UserMv(user, GetUserRoles(user).Result)).ToList()));
            }
    
            private async Task<List<string>> GetUserRoles(IdentityUser user)
            {
                return new List<string>(await _userManager.GetRolesAsync(user));
            }
    }
