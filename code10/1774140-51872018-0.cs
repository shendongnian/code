    private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public HomeController(ApplicationDbContext context
            , UserManager<ApplicationUser> userManager
            , RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task<IActionResult> CreateUserAndRole()
        {
            await _userManager.CreateAsync(new ApplicationUser { UserName = "test@outlook.com", Email = "test@outlook.com" });
            await _roleManager.CreateAsync(new IdentityRole {  Name = "Admin" });
            await _roleManager.CreateAsync(new IdentityRole { Name = "Administrator" });
            return Ok();
        }
        public async Task<IActionResult> AddAdminRoleToUser()
        {
            ApplicationUser user = _context.Users.FirstOrDefault(u => u.UserName == "test@outlook.com");
            var role = await _roleManager.FindByNameAsync("Admin");
            user.Roles.Add(new IdentityUserRole<string> { RoleId = role.Id, UserId = user.Id });
            await _userManager.UpdateAsync(user);
            return Ok();
        }
        public async Task<IActionResult> AddAdministratorRoleToUser()
        {
            ApplicationUser user = _context.Users.FirstOrDefault(u => u.UserName == "test@outlook.com");
            var role = await _roleManager.FindByNameAsync("Administrator");
            user.Roles.Add(new IdentityUserRole<string> { RoleId = role.Id, UserId = user.Id });
            await _userManager.UpdateAsync(user);
            return Ok();
        }
