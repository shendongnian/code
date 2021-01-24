    [Authorize]
    public class RoleController : Controller
    {
        private ApplicationRoleManager _roleManager;
        public RoleController() { }
        public RoleController(ApplicationRoleManager roleManager)
        {
            RoleManager = roleManager;
        }
        public ApplicationRoleManager RoleManager
        {
            get
            {
                return _roleManager ?? 
                    HttpContext.GetOwinContext().Get<ApplicationRoleManager>();
            }
            private set { _roleManager = value; }
        }
        public ActionResult Index()
        {
            var model = RoleManager.Roles.ToList();
            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Create(ApplicationRoleCreateModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await RoleManager.CreateAsync(new ApplicationRole()
                {
                    Name = model.Name,
                    ApplicationId = model.ApplicationId
                });
                if (result.Succeeded)
                    return RedirectToAction("Index");
                else
                    foreach (var error in result.Errors)
                        ModelState.AddModelError("", error);
            }
            return View();
        }
    }
