    [AllowAnonymous]
            public ActionResult StaffRegister()
            {
                ApplicationDbContext context = new ApplicationDbContext();
                var roles = context.Roles.ToList();
                var viewModel = new StaffRegisterViewModel
                {
                    RoleNames = roles.ToSelectListItem(x=>x.Name, y=>y.Id);
                };
                return View(viewModel);
            }
