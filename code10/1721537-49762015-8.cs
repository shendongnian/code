    [AllowAnonymous]
            public ActionResult StaffRegister()
            {
                ApplicationDbContext context = new ApplicationDbContext();
                var roles = context.Roles.ToList();
                var viewModel = new StaffRegisterViewModel
                {
                    RoleNames =  new SelectListItem(roles, "Id","Name");
                };
                return View(viewModel);
            }
