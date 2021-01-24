    [AllowAnonymous]
            public ActionResult StaffRegister()
            {
                ApplicationDbContext context = new ApplicationDbContext();
                var roles = context.Roles.ToList();
                var rolesSelctedListItems= new List<SelectListItem>();
               
         foreach(var item in roles)   {
                  rolesSelctedListItems.Add(new SelectListItem  {
                       Text = item.Name,
                       Value = item.Id,           
                         });
                   }
                var viewModel = new StaffRegisterViewModel
                {
                    RoleNames =  rolesSelctedListItems
                };
                return View(viewModel);
            }
