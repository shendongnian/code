    [Authorize(AuthenticationSchemes = HomebrewModel.BothAuthSchemes, Roles = HomebrewModel.RoleAdmin)]
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<NutricionUser> _userManager;
        public RoleController(RoleManager<IdentityRole> roleManager, UserManager<NutricionUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }
        // GET: Role
        public async Task<ActionResult> Index()
        {
            var adminRole = await _roleManager.FindByNameAsync(HomebrewModel.RoleAdmin);
            var assignableRoles = _roleManager.Roles.ToList();
            assignableRoles.RemoveAt(assignableRoles.IndexOf(adminRole));
            return View(assignableRoles);
        }
        // GET: Role/Assign
        public async Task<ActionResult> Assign()
        {
            var adminRole = await _roleManager.FindByNameAsync(HomebrewModel.RoleAdmin);
            var assignableRoles = _roleManager.Roles.ToList();
            assignableRoles.RemoveAt(assignableRoles.IndexOf(adminRole));
            ViewData["Name"] = new SelectList(assignableRoles, "Name", "Name");
            ViewData["UserName"] = new SelectList(_userManager.Users, "UserName", "UserName");
            return View(new RoleModel());
        }
        // POST: Role/Assign
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Assign(RoleModel roleModel)
        {
            if (ModelState.IsValid)
            {
                if(roleModel.Name == HomebrewModel.RoleAdmin)
                {
                    ViewData["Message"] = "Invalid Request.";
                    return View("Info");
                }
                var user = await _userManager.FindByEmailAsync(roleModel.UserName);
                if (user != null)
                {
                    if (await _roleManager.RoleExistsAsync(roleModel.Name))
                    {
                        if(await _userManager.IsInRoleAsync(user, roleModel.Name))
                        {
                            ViewData["Message"] = $@"User {roleModel.UserName} already has the {roleModel.Name} role.";
                            return View("Info");
                        }
                        else
                        {
                            await _userManager.AddToRoleAsync(user, roleModel.Name);
                            ViewData["Message"] = $@"User {roleModel.UserName} was assigned the {roleModel.Name} role.";
                            return View("Info");
                        }
                    }
                    else
                    {
                        ViewData["Message"] = "Invalid Request.";
                        return View("Info");
                    }
                }
                else
                {
                    ViewData["Message"] = "Invalid Request.";
                    return View("Info");
                }
            }
            return View(roleModel);
        }
    }
